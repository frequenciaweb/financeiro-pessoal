using FinanceiroPessoal.Dominio.Entidades;

namespace FinanceiroPessoal.Dominio.Contratos.Repositorios
{
    public interface ICategoriaLancamentoRepositorio : IRepositorioBase<CategoriaLancamento>
    {
        CategoriaLancamento? ObterPorNome(string nome);
    }
}
