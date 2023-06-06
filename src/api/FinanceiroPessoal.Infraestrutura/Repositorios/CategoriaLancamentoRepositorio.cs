using FinanceiroPessoal.Dominio.Contratos.Repositorios;
using FinanceiroPessoal.Dominio.Entidades;
using FinanceiroPessoal.Infraestrutura.EF;
using FinanceiroPessoal.Infraestrutura.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceiroPessoal.Infraestrutura.Dados.Repositorios
{
    public class CategoriaLancamentoRepositorio : RepositorioBase<CategoriaLancamento>, ICategoriaLancamentoRepositorio
    {
        public CategoriaLancamentoRepositorio(FinanceiroPessoalContext context) : base(context)
        {
        }

        public CategoriaLancamento? ObterPorNome(string nome)
        {
            return Context.CategoriasLancamentos.FirstOrDefault(x => x.Nome.Contains(nome));
        }
    }
}
