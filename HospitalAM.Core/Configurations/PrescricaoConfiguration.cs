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
    public class PrescricaoConfiguration : IEntityTypeConfiguration<Prescricao>
    {
        public void Configure(EntityTypeBuilder<Prescricao> builder)
        {
            builder.ToTable("Prescricao");
            builder.HasKey(x => x.IdPrescricao);

            builder.Property(x => x.Conteudo)
                .IsRequired()
                .HasMaxLength(2000);

            builder.HasOne(x => x.Consulta)
                .WithMany(c => c.Prescricoes)
                .HasForeignKey(x => x.IdConsulta)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.Medico)
                .WithMany()
                .HasForeignKey(x => x.IdMedico)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
