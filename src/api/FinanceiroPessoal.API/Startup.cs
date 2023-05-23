using FinanceiroPessoal.Infraestrutura.EF;
using Microsoft.EntityFrameworkCore;

namespace FinanceiroPessoal.API
{
    public static class Startup
    {
        public static void ConfigurarConexaoBanco(this IServiceCollection services, IConfiguration config)
        {
            string? connectionString = config["connection_string"]?.ToString();
            Thread.Sleep(10000);
            if (string.IsNullOrEmpty(connectionString))
            {
                connectionString = config.GetConnectionString("padrao");
            }
            Console.WriteLine("Conection string: " + connectionString);
            services.AddDbContext<FinanceiroPessoalContext>(options => options.UseNpgsql(connectionString));

        }

        public static void IniciarBancoDeDados(this WebApplication app, IConfiguration config)
        {
            try
            {
                using (IServiceScope scope = app.Services.CreateScope())
                {
                    IServiceProvider services = scope.ServiceProvider;
                    FinanceiroPessoalContext context = services.GetRequiredService<FinanceiroPessoalContext>();
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
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
