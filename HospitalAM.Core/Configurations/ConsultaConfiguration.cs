using HospitalAM.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalAM.Core.Configurations
{
    internal class ConsultaConfiguration : IEntityTypeConfiguration<Consulta>
    {
        public void Configure(EntityTypeBuilder<Consulta> builder)
        {
            builder.ToTable("Consulta");
            builder.HasKey(x => x.IdConsulta);

            builder.Property(x => x.DataHora) // date or datetime? choose:
                .HasColumnType("datetime2") // use "date" if you only store the date
                .IsRequired();

            builder.Property(x => x.Diagnostico)
                .HasMaxLength(1000);

            builder.HasOne(x => x.Medico)
                .WithMany(m => m.Consultas)
                .HasForeignKey(x => x.IdMedico)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Paciente)
                .WithMany(p => p.Consultas)
                .HasForeignKey(x => x.IdPaciente)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
