using HospitalAM.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace HospitalAM.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Medico> Medico => Set<Medico>();
        public DbSet<Paciente> Paciente => Set<Paciente>();
        public DbSet<Consulta> Consulta => Set<Consulta>();
        public DbSet<Prescricao> Prescricao => Set<Prescricao>();
        public DbSet<Exame> Exame => Set<Exame>();
        public DbSet<Hospital> Hospital => Set<Hospital>();
        public DbSet<Empresa> Empresa => Set<Empresa>();
        public DbSet<Login> Login => Set<Login>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }

    }
}
