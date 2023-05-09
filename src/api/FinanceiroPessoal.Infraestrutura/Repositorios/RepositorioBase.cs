using FinanceiroPessoal.Dominio.Contratos;
using FinanceiroPessoal.Infraestrutura.EF;

namespace FinanceiroPessoal.Infraestrutura.Repositorios
{
    public abstract class RepositorioBase<T> : IRepositorioBase<T> where T : class
    {
        protected readonly FinanceiroPessoalContext Context = default!;

        public RepositorioBase(FinanceiroPessoalContext context)
        {
            Context = context;
        }

        public T Alterar(T obj)
        {
            Context.Set<T>().Update(obj);
            return obj;
        }

        public void Alterar(List<T> objs)
        {
            Context.Set<T>().UpdateRange(objs);
        }

        public void Excluir(T obj)
        {
            Context.Set<T>().Remove(obj);
        }

        public T Incluir(T obj)
        {
            Context.Set<T>().Add(obj);
            return obj;
        }

        public void Incluir(List<T> objs)
        {
            Context.Set<T>().AddRange(objs);
        }

        public T? Obter(Guid id)
        {
            return Context.Set<T>().Find(id);
        }

        public IEnumerable<T> Obter()
        {
            return Context.Set<T>().ToList();
        }
    }
}
