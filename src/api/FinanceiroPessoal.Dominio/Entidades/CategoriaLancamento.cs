using FinanceiroPessoal.Dominio.Util;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinanceiroPessoal.Dominio.Entidades
{
    [Table("lancamento_categorias")]
    public class CategoriaLancamento : EntidadeBase
    {
        public CategoriaLancamento(string nome, string usuarioInclusao) : base(usuarioInclusao)
        {
            Nome = nome;
        }

        [Column("nome"), MaxLength(30), Required]
        public string Nome { get; private set; } = default!;
    }
}
