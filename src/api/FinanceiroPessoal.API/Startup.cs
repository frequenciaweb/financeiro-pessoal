using FinanceiroPessoal.Infraestrutura.EF;
using Microsoft.EntityFrameworkCore;

namespace FinanceiroPessoal.API
{
    public static class Startup
    {
        private static string ObterConnectionString(IConfiguration config)
        {
            string? connectionString = config["connection_string"]?.ToString();
            if (string.IsNullOrEmpty(connectionString))
            {
                Console.WriteLine("Conection string: " + connectionString);
                return config.GetConnectionString("padrao");
            }
            Console.WriteLine("Aguardar 10 segundos");
            Thread.Sleep(10000);
            Console.WriteLine("Conection string: " + connectionString);
            return connectionString;
        }

        public static void ConfigurarConexaoBanco(this IServiceCollection services, IConfiguration config)
        {
            var connectionString = ObterConnectionString(config);
            services.AddDbContext<FinanceiroPessoalContext>(options => options.UseNpgsql(connectionString));
        }

        public static void IniciarBancoDeDados(this WebApplication app, IConfiguration config)
        {
            try
            {
                DbContextOptionsBuilder<FinanceiroPessoalContext> dbContextOptions = new DbContextOptionsBuilder<FinanceiroPessoalContext>();
                string connectionString = ObterConnectionString(config);
                dbContextOptions.UseNpgsql(connectionString);
                FinanceiroPessoalContext context = new FinanceiroPessoalContext(dbContextOptions.Options);
                try
                {
                    context.ChangeTracker
                   .Entries()
                   .ToList()
                   .ForEach(e => e.State = EntityState.Detached);

                    if (config["DROP_DATA_BASE"] != null && int.Parse(config["DROP_DATA_BASE"]) == 1)
                    {
                        if (app.Environment.IsDevelopment())
                        {
                            context.Database.EnsureDeleted();//em desenvolvimento dropar sempre o banco
                        }
                    }

                    if (context.Database.EnsureCreated())
                    {
                        context.Database.Migrate();
                    }

                }
                catch (Exception ex)
                {
                    //logger.LogError(ex, "An error occurred creating the DB.");
                }

                if (config["POPULAR_DATA_BASE"] != null && int.Parse(config["POPULAR_DATA_BASE"]) == 1)
                {
                    SEED.Popular(context);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
