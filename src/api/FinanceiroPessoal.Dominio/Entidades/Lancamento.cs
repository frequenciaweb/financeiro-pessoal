using FinanceiroPessoal.Dominio.Enumeradores;
using FinanceiroPessoal.Dominio.Util;
using System.ComponentModel.DataAnnotations;
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
        [Column("vencimento"), Required]
        public DateTime Vencimento { get; private set; }

        /// <summary>
        ///  Situação do lançamento (Pago, Recebido, Pendente, Cancelado)
        /// </summary>
        [Column("situacao"), Required]
        public EnumSituacaoLancamento Situacao { get; private set; }

        /// <summary>
        /// Tipo de Lançamento  APagar, AReceber
        /// </summary>
        [Column("tipo"), Required]
        public EnumTipoLancamento Tipo { get; private set; }

        /// <summary>
        /// Detalhes da conta ou valor a ser recebido
        /// </summary>
        [Column("descricao"), Required, MaxLength(60)]
        public string Descricao { get; private set; } = default!;

        /// <summary>
        /// Valor para pagamento ou recebimento
        /// </summary>
        [Column("valor"), Required]
        public decimal Valor { get; private set; } = 0;

        /// <summary>
        /// Valor final recebido ou pago
        /// </summary>
        [Column("valor_efetivado")]
        public decimal ValorEfetivado { get; private set; } = 0;

        /// <summary>
        /// Valor de desconto
        /// </summary>
        [Column("valor_desconto")]
        public decimal ValorDesconto { get; private set; } = 0;

        /// <summary>
        /// Valor de crescimo
        /// </summary>
        [Column("valor_acrescimo")]
        public decimal ValorAcrescimo { get; private set; } = 0;

        public Usuario Usuario { get; private set; } = default!;

        /// <summary>
        ///  Código do Usuário responsavel pelo lançamento
        /// </summary>
        [ForeignKey("Usuario"), Column("usuario_id")]
        public Guid UsuarioID { get; private set; }

        public CategoriaLancamento CategoriaLancamento { get; private set; } = default!;

        /// <summary>
        ///  Código da categoria do lançamento saude, lazer, alimentacao...
        /// </summary>
        [ForeignKey("CategoriaLancamento"), Column("categoria_lancamento_id"), Required]
        public Guid CategoriaLancamentoID { get; private set; }

        /// <summary>
        /// Forma de pagamento/recebimento 
        /// Pix, CartaoCredito,CartaoDebito,Boleto, Transferencia,Especie, Cheque, Deposito, DebitoEmConta
        /// </summary>
        [Column("forma_pagmento"), Required]
        public EnumFormaPagamento FormaPagamento { get; private set; }

    }
}
