using FinanceiroPessoal.Dominio.Enumeradores;
using FinanceiroPessoal.Dominio.Util;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinanceiroPessoal.Dominio.Entidades
{
    [Table("cartao_credito")]
    public class CartaoCredito : EntidadeBase
    {
        /// <summary>
        ///  Nome do cartão (Way, sx, platinum, gold)
        /// </summary>
        [Column("nome"), MaxLength(20), Required]
        public string Nome { get; private set; } = default!;

        /// <summary>
        ///  Número do Cartão
        /// </summary>
        [Column("numero_cartao"), MaxLength(16), Required]
        public string Numero { get; private set; } = default!;

        [Column("codigo_seguranca"), MaxLength(3)]
        public string? CVV { get; private set; }

        /// <summary>
        ///  Data de expiração do cartão
        /// </summary>
        [Column("validade"), MaxLength(6)]
        public string Validade { get; private set; } = default!;

        /// <summary>
        ///  Dia do Vencimento do cartão
        /// </summary>
        [Column("vencimento"), Required]
        public int Vencimento { get; private set; }

        /// <summary>
        ///  Melhor dia de compra
        /// </summary>
        [Column("melhor_dia")]
        public int DiaMelhorCompra { get;private set; }

        /// <summary>
        /// Valor total do limite
        /// </summary>
        [Column("limite")]
        public decimal Limite { get; private set; }

        /// <summary>
        /// Nome do banco
        /// </summary>
        [Column("banco"),MaxLength(30),Required]
        public string Banco { get; private set; } = default!;

        /// <summary>
        /// Bandeiras de cartoes  Visa, MasterCard, AmericanExpress, Elo
        /// </summary>
        [Column("bandeira"), Required]
        public EnumBandeiraCartao Bandeira { get; private set; }

        private List<FaturaCartao> _faturas  = new List<FaturaCartao>();        

        public IReadOnlyList<FaturaCartao> Faturas => _faturas;
    }
}