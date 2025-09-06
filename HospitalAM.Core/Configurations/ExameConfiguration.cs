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
    public class ExameConfiguration : IEntityTypeConfiguration<Exame>
    {
        public void Configure(EntityTypeBuilder<Exame> builder)
        {
            builder.ToTable("Exame");
            builder.HasKey(x => x.IdExame);

            builder.Property(x => x.Pedido)
                .IsRequired()
                .HasMaxLength(1000);

            builder.Property(x => x.Resultado)
                .HasMaxLength(2000);

            builder.HasOne(x => x.Consulta)
                .WithMany(c => c.Exames)
                .HasForeignKey(x => x.IdConsulta)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
