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
    public class HospitalConfiguration : IEntityTypeConfiguration<Hospital>
    {
        public void Configure(EntityTypeBuilder<Hospital> builder)
        {
            builder.ToTable("Hospital");
            builder.HasKey(x => x.IdHospital);

            builder.Property(x => x.Nome)
                .IsRequired()
                .HasMaxLength(150);

            builder.HasOne(x => x.Empresa)
                .WithMany(e => e.Hospitais)
                .HasForeignKey(x => x.IdEmpresa)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
