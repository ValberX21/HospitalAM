using HospitalAM.Core.Entities;                          // sua entidade
using Microsoft.EntityFrameworkCore;                      // <-- ToTable, HasIndex, etc.
using Microsoft.EntityFrameworkCore.Metadata.Builders;    // <-- EntityTypeBuilder<T>

namespace HospitalAM.Core.Configurations
{
    public class MedicoConfiguration : IEntityTypeConfiguration<Medico>
    {
        public void Configure(EntityTypeBuilder<Medico> builder)
        {
            builder.ToTable("Medico");
            builder.HasKey(x => x.IdMedico);

            builder.Property(x => x.Nome)
                .IsRequired()
                .HasMaxLength(150);

            builder.Property(x => x.CRM)
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(x => x.Email)
                .IsRequired()
                .HasMaxLength(255);

            builder.HasIndex(x => x.Email).IsUnique();

            builder.HasOne(x => x.Hospital)
                .WithMany()
                .HasForeignKey(x => x.IdHospital)
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
