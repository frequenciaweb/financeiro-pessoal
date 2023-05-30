using FinanceiroPessoal.Dominio.Enumeradores;
using FinanceiroPessoal.Dominio.Util;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinanceiroPessoal.Dominio.Entidades
{
    [Table("cartao_credito_fatura")]
    public class FaturaCartao : EntidadeBase
    {
        public FaturaCartao(decimal valor, Guid cartaoCreditoID,Guid lancamentoID, string usuarioInclusao) : base(usuarioInclusao)
        {
            CartaoCreditoID = cartaoCreditoID;
            LancamentoID = lancamentoID;
            Valor = valor;
        }

        [Column("cartao_credito_id")]
        [ForeignKey("CartaoCredito")]
        public Guid CartaoCreditoID { get; private set; }
        public CartaoCredito CartaoCredito { get; private set; } = default!;

        [Column("valor_fatura")]
        public decimal Valor { get; private set; }

        [Column("situacao")]
        public EnumSituacaoPagamentoFatura Situacao { get; private set; }

        public Lancamento Lancamento { get; private set; } = default!;

        [Column("lancamento_id"), ForeignKey("Lancamento")]
        public Guid LancamentoID {get; private set; }

        public override bool Valido()
        {
            if (Valor <= 0)
            {
                IncluirAnotacaoErro("Valor da fatura deve ser especificado corretamente");
            }

            return base.Valido();
        }
    }
}
