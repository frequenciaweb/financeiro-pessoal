using FinanceiroPessoal.Dominio.Enumeradores;
using FinanceiroPessoal.Dominio.Util;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinanceiroPessoal.Dominio.Entidades
{
    /// <summary>
    /// Entidade responsavel por armazenar todos os lançamentos a pagar e a receber
    /// </summary>
    [Table("lancamentos")]
    public class Lancamento : EntidadeBase
    {
        /// <summary>
        /// Data de Vencimento do Lançamento
        /// </summary>        
        public DateTime Vencimento { get; private set; }

        /// <summary>
        ///  Situação do lançamento (Pago, Recebido, Pendente, Cancelado)
        /// </summary>
        public EnumSituacaoLancamento Situacao { get; private set; }

        /// <summary>
        /// Tipo de Lançamento  APagar, AReceber
        /// </summary>
        public EnumTipoLancamento Tipo { get; private set; }

        /// <summary>
        /// Detalhes da conta ou valor a ser recebido
        /// </summary>
        public string Descricao { get; private set; } = default!;

        /// <summary>
        /// Valor para pagamento ou recebimento
        /// </summary>
        public decimal Valor { get; private set; }

        /// <summary>
        /// Valor final recebido ou pago
        /// </summary>
        public decimal ValorEfetivado { get; private set; }

        /// <summary>
        /// Valor de desconto
        /// </summary>
        public decimal ValorDesconto { get; private set; }

        /// <summary>
        /// Valor de crescimo
        /// </summary>
        public decimal ValorAcrescimo { get; private set; }

        public Usuario Usuario { get; private set; } = default!;

        /// <summary>
        ///  Código do Usuário responsavel pelo lançamento
        /// </summary>
        public Guid UsuarioID { get; private set; }

        public CategoriaLancamento CategoriaLancamento { get; private set; } = default!;

        /// <summary>
        ///  Código da categoria do lançamento
        /// </summary>
        public Guid CategoriaLancamentoID { get; private set; }

        /// <summary>
        /// Forma de pagamento/recebimento 
        /// Pix, CartaoCredito,CartaoDebito,Boleto, Transferencia,Especie, Cheque, Deposito, DebitoEmConta
        /// </summary>
        public EnumFormaPagamento Forma { get; private set; }

        /// <summary>
        /// Código do cartão
        /// </summary>
        public Guid CartaoCreditoID { get; private set; }
        public CartaoCredito CartaoCredito { get; private set; } = default!;
    }
}
