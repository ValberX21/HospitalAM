using Castle.Core.Logging;
using FluentAssertions;
using HospitalAM.Application.Commands;
using HospitalAM.Application.Handlers;
using HospitalAM.Core.Entities;
using HospitalAM.Infrastructure.Data;
using HospitalAM.Infrastructure.Persistence;
using HospitalAM.Infrastructure.Repository;
using HospitalAM.Test.Util;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalAM.Test.Integrations
{
    public class CreateMedicoHandler_IntegrationTests : IDisposable
    {
        private readonly TestDbFixture _fx;
        private readonly ApplicationDbContext _ctx;

        public CreateMedicoHandler_IntegrationTests()
        {
           _fx = new TestDbFixture();
           _ctx = _fx.CreateContext();
        }

        [Fact(DisplayName="Integração com o bando de dados")]
        public async Task Integration_Task()
        {
            var repo = new MedicoRepository(_ctx);
            var ouw = new UnitOfWork(_ctx);
            var logger = NullLogger<CreateMedicoHandler>.Instance;

            var handler = new CreateMedicoHandler(repo, ouw, logger);

            var cmd = new CreateMedicoCommand
            {
                IdHospital = 10,
                Nome = "Dr. House",
                CPF = "123.456.789-00", // formatado de propósito
                DataNascimento = new DateTime(1980, 5, 1),
                Genero = "M",
                Email = "house@hospital.com",
                Telefone = "(11) 99999-0000",
                Endereco = "Rua X, 123",
                CRM = "CRM-12345",
                Especialidade = "Clínico Geral",
                Ativo = true,
                IdEmpresa = 1
            };

            var resultId = await handler.Handle(cmd, CancellationToken.None);

            var saved = await _ctx.Set<Medico>()
                .AsNoTracking()
                .SingleOrDefaultAsync(m => m.Email == "house@hospital.com");

            saved.Should().NotBeNull("o médico precisa existir no banco após o commit");
            saved!.IdMedico.Should().BeGreaterThan(0);
            saved.Nome.Should().Be("Dr. House");
            saved.CPF.Should().Be("12345678900"); // normalizado pelo handler
            saved.IdHospital.Should().Be(10);
            saved.CRM.Should().Be("CRM-12345");
            saved.Ativo.Should().BeTrue();
        }

        public void Dispose()
        {
            _ctx.Dispose();            
        }
    }
}
