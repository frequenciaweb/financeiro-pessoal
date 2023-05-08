using FinanceiroPessoal.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace FinanceiroPessoal.Infraestrutura.EF
{
    public class FinanceiroPessoalContext : DbContext
    {

        public FinanceiroPessoalContext()
        {
            
        }

        protected FinanceiroPessoalContext(DbContextOptions<FinanceiroPessoalContext> dbcontext)
            : base(dbcontext)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {   
                IConfigurationBuilder builder = new ConfigurationBuilder()
               .AddJsonFile("appsettings.json");
                IConfiguration _config = builder.Build();

                string connectionString = _config.GetConnectionString("padrao");
                optionsBuilder.UseNpgsql(connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
         
        }
    }
}
