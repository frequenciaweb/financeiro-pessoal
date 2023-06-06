using FinanceiroPessoal.Dominio.Contratos.Servicos;
using FinanceiroPessoal.Infraestrutura.EF;

namespace FinanceiroPessoal.Aplicacao.Servicos
{
    public abstract class ServicoBase : IServicoBase
    {

        private readonly FinanceiroPessoalContext _contexto;

        public ServicoBase(FinanceiroPessoalContext contexto)
        {
            _contexto = contexto;
        }

        public int Commit()
        {
            return _contexto.SaveChanges();
        }
    }
}
