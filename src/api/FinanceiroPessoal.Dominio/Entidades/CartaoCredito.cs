using FinanceiroPessoal.Dominio.Enumeradores;
using FinanceiroPessoal.Dominio.Util;

namespace FinanceiroPessoal.Dominio.Entidades
{
    public class CartaoCredito : EntidadeBase
    {

        /// <summary>
        ///  Nome do cartão (Way, sx, platinum, gold)
        /// </summary>
        public string Nome { get; private set; } = default!;

        /// <summary>
        ///  Número do Cartão
        /// </summary>
        public string Numero { get; private set; } = default!;
        public string? CVV { get; private set; }

        /// <summary>
        ///  Data de expiração do cartão
        /// </summary>
        public string Validade { get; private set; } = default!;

        /// <summary>
        ///  Dia do Vencimento do cartão
        /// </summary>
        public int Vencimento { get; private set; }
          
        /// <summary>
        ///  Melhor dia de compra
        /// </summary>
        public int DiaMelhorCompra { get;private set; }

        /// <summary>
        /// Valor total do limite
        /// </summary>
        public decimal Limite { get; private set; }

        /// <summary>
        /// Nome do banco
        /// </summary>
        public string Banco { get; private set; } = default!;

        /// <summary>
        /// Bandeiras de cartoes  Visa, MasterCard, AmericanExpress, Elo
        /// </summary>
        public EnumBandeiraCartao Bandeira { get; private set; }

    }
}
