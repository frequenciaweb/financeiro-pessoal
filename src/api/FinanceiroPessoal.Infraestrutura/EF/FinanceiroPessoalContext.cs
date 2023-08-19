using FinanceiroPessoal.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace FinanceiroPessoal.Infraestrutura.EF
{
    public class FinanceiroPessoalContext : DbContext
    {

        public DbSet<CartaoCredito> Cartoes { get; set; } = default!;
        public DbSet<CategoriaLancamento> CategoriasLancamentos { get; set; } = default!;
        public DbSet<FaturaCartao> Faturas { get; set; } = default!;
        public DbSet<Lancamento> Lancamentos { get; set; } = default!;
        public DbSet<Usuario> Usuarios { get; set; } = default!;
        public DbSet<Acesso> Acessos { get; set; } = default!;


        public FinanceiroPessoalContext()
        {
            
        }

        public FinanceiroPessoalContext(DbContextOptions<FinanceiroPessoalContext> dbcontext)
            : base(dbcontext)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {   
                IConfigurationBuilder builder = new ConfigurationBuilder()
               .AddJsonFile(path: "appsettings.json");
                IConfiguration _config = builder.Build();

                bool sqlite = _config["USE_SQLITE"]?.ToString() == "True";

                string connectionString = _config.GetConnectionString("padrao");
                if (sqlite)
                {   
                    optionsBuilder.UseSqlite(connectionString);
                }
                else
                {   
                    optionsBuilder.UseNpgsql(connectionString);
                }
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
         
        }       
    }
}
