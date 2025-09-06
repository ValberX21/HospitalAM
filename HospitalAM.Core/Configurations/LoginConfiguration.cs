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
    public class LoginConfiguration : IEntityTypeConfiguration<Login>
    {
        public void Configure(EntityTypeBuilder<Login> builder)
        {
            builder.ToTable("Login");
            builder.HasKey(x => x.IdLogin);

            builder.Property(x => x.Usuario)
                .IsRequired()
                .HasMaxLength(150);

            builder.Property(x => x.Email)
                .IsRequired()
                .HasMaxLength(255);

            builder.HasIndex(x => x.Email).IsUnique();

            builder.Property(x => x.Usuario)
                .IsRequired()
                .HasMaxLength(100);

            builder.HasIndex(x => x.Usuario).IsUnique();

            builder.Property(x => x.SenhaHash)
                .IsRequired()
                .HasMaxLength(500); 
        }
    }
}
