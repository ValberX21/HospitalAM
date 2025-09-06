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
    public class PacienteConfiguration : IEntityTypeConfiguration<Paciente>
    {
        public void Configure(EntityTypeBuilder<Paciente> builder)
        {
            builder.ToTable("Paciente");
            builder.HasKey(x => x.IdPaciente);

            builder.Property(x => x.Nome)
                .IsRequired()
                .HasMaxLength(150);

            builder.Property(x => x.CPF)
                .IsRequired()
                .HasColumnType("char(11)");

            builder.HasIndex(x => x.CPF).IsUnique();

            builder.Property(x => x.Genero)
                .IsRequired()
                .HasColumnType("char(1)");

            builder.Property(x => x.Email)
                .IsRequired()
                .HasMaxLength(255);
        }
    }
}
