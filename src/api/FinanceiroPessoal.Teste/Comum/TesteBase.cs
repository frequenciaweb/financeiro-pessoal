using FinanceiroPessoal.Infraestrutura.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace FinanceiroPessoal.Teste.Comum
{
    public abstract class TesteBase
    {
        private static object Objecto = new object(); 
        private static FinanceiroPessoalContext _context;
        protected static FinanceiroPessoalContext Context
        {
            get
            {
                lock (Objecto)
                {
                    if (_context != null)
                    {
                        return _context;
                    }
                    return CriarInstancia();
                }
            }
        }

        private static FinanceiroPessoalContext CriarInstancia()
        {
            IConfigurationBuilder builder = new ConfigurationBuilder()
             .AddJsonFile(path: "appsettings.json");
            IConfiguration _config = builder.Build();

            DbContextOptionsBuilder<FinanceiroPessoalContext> dbcontext = new DbContextOptionsBuilder<FinanceiroPessoalContext>();
            dbcontext.UseSqlite(_config.GetConnectionString("padrao"));
            _context = new FinanceiroPessoalContext(dbcontext.Options);
            _context.Database.EnsureDeleted();
            _context.Database.EnsureCreated();

            SEED.Popular(_context);
            return _context;
        }
    }
}
