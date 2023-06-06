namespace FinanceiroPessoal.Dominio.Contratos.Repositorios
{
    public interface IRepositorioBase<T> where T : class
    {
        T Incluir(T obj);
        void Incluir(List<T> objs);
        T Alterar(T obj);
        void Alterar(List<T> objs);
        void Excluir(T obj);
        T? Obter(Guid id);
        IEnumerable<T> Obter();
    }
}
