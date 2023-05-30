using FinanceiroPessoal.Dominio.Util;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinanceiroPessoal.Dominio.Entidades
{
    /// <summary>
    ///  Categoria do lançamento, saude, lazer, alimentacao...
    /// </summary>
    [Table("lancamento_categorias")]    
    public class CategoriaLancamento : EntidadeBase
    {
        public CategoriaLancamento(string nome, string usuarioInclusao) : base(usuarioInclusao)
        {
            Nome = nome;
        }

        [Column("nome"), MaxLength(30), Required]
        public string Nome { get; private set; } = default!;

        public override bool Valido()
        {

            if (string.IsNullOrWhiteSpace(Nome))
            {
                IncluirAnotacaoErro("Nome da catetoria deve ser preenchido");
            }

            if (!string.IsNullOrWhiteSpace(Nome) && Nome.Length > 30)
            {
                IncluirAnotacaoErro("Nome da catetoria não pode ultrapassar 30 caracteres");
            }

            if (!string.IsNullOrWhiteSpace(Nome) && Nome.Length < 10)
            {
                IncluirAnotacaoErro("Nome da catetoria deve conter pelo menos 10 caracteres");
            }

            return base.Valido();
        }
    }
}
