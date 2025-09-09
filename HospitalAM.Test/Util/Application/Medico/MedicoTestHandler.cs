using FluentAssertions;
using HospitalAM.Application.Commands;
using HospitalAM.Application.Handlers;
using HospitalAM.Core.Entities;
using HospitalAM.Core.Interfaces.Repository;
using Microsoft.Extensions.Logging;
using Moq;

namespace HospitalAM.Test;

public class MedicoTestHandler
{
    private readonly Mock<IMedicoRepository> _repoMock = new();
    private readonly Mock<IUnitOfWork> _uowMock = new();
    private readonly Mock<ILogger<CreateMedicoHandler>> _loggerMock = new();
    
    private CreateMedicoHandler CreateSut()
    {
        return new CreateMedicoHandler(_repoMock.Object, _uowMock.Object, _loggerMock.Object);
    }

    [Fact(DisplayName = "Create Medico")]
    public async Task Create_Medico()
    {
        var ct = new CancellationToken();

        var cmd = new CreateMedicoCommand
        {
            IdHospital = 10,
            Nome = "Dr. House",
            CPF = "123.456.789-00",
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

        var generatedId = 0;
        Medico captured = null;

        _repoMock.Setup(r => r.AddAsync(It.IsAny<Medico>(), ct))
            .Callback<Medico, CancellationToken>((m, _) => captured = m)
            .ReturnsAsync(generatedId);

        _uowMock.Setup(u => u.CommitAsync(ct))
            .ReturnsAsync(1);

        var sut =  CreateSut();

        var result = await sut.Handle(cmd, ct);

        result.Should().Be(generatedId);

        captured.Should().NotBeNull();
        captured.IdHospital.Should().Be(cmd.IdHospital);
        captured.Nome.Should().Be(cmd.Nome);
        captured.CPF.Should().Be("12345678900"); 
        captured.DataNascimento.Should().Be(cmd.DataNascimento);
        captured.Email.Should().Be(cmd.Email);
        captured.Telefone.Should().Be(cmd.Telefone);
        captured.Endereco.Should().Be(cmd.Endereco);
        captured.CRM.Should().Be(cmd.CRM);
        captured.Especialidade.Should().Be(cmd.Especialidade);
        captured.Ativo.Should().BeTrue();
        captured.IdEmpresa.Should().Be(cmd.IdEmpresa);

        _repoMock.Verify(r => r.AddAsync(It.IsAny<Medico>(), ct), Times.Once);
        _uowMock.Verify(u => u.CommitAsync(ct), Times.Once);

    }

}
