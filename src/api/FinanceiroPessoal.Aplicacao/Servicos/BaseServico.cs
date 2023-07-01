using FinanceiroPessoal.Dominio.Contratos.Servicos;
using FinanceiroPessoal.Infraestrutura.EF;

namespace FinanceiroPessoal.Aplicacao.Servicos
{
    public abstract class BaseServico : IBaseServico
    {

        private readonly FinanceiroPessoalContext _contexto;

        public BaseServico(FinanceiroPessoalContext contexto)
        {
            _contexto = contexto;
        }

        public int Commit()
        {
            return _contexto.SaveChanges();
        }
    }
}
