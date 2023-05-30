using FinanceiroPessoal.Dominio.Entidades;

namespace FinanceiroPessoal.Dominio.Contratos
{
    public interface ICategoriaLancamentoRepositorio : IRepositorioBase<CategoriaLancamento>
    {
        CategoriaLancamento? ObterPorNome(string nome); 
    }
}
