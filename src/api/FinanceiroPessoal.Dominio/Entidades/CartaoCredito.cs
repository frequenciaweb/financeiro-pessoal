using FinanceiroPessoal.Dominio.Enumeradores;
using FinanceiroPessoal.Dominio.Util;
using FinanceiroPessoal.Utilitarios.Util;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinanceiroPessoal.Dominio.Entidades
{
    [Table("cartao_credito")]
    public class CartaoCredito : EntidadeBase
    {
        public CartaoCredito()
        {
            
        }

        public CartaoCredito(string nome, string numero, string? cvv, string validade, int vencimento, int diaMelhorCompra, decimal limite, string banco, EnumBandeiraCartao bandeira, string usuarioInclusao):base(usuarioInclusao)
        {
            Nome = nome;
            Numero = numero;
            CVV = cvv;
            Validade = validade;
            Vencimento = vencimento;
            DiaMelhorCompra = diaMelhorCompra;
            Limite = limite;
            Banco = banco;
            Bandeira = bandeira;
        }

        /// <summary>
        ///  Nome do cartão (Way, sx, platinum, gold)
        /// </summary>
        [Column("nome"), MaxLength(20), Required]
        public string Nome { get; private set; } = default!;

        public void Alterar(string nome, 
            string numero,
            string cvv,
            string validade,
            int vencimento, 
            int diaMelhorCompra,
            EnumBandeiraCartao bandeira,
            decimal limite,
            string banco, string usuarioAlteracao)
        {
            Nome = nome.Trim().ToLower();
            Numero = numero.Trim().ToLower();
            CVV = cvv.Trim().ToLower();
            Validade = validade.Trim().ToLower();
            Vencimento = vencimento;
            DiaMelhorCompra = diaMelhorCompra;
            Banco = banco.Trim().ToLower();
            Bandeira = bandeira;            
            Limite = limite;
            IncluirInformacoesAlteracao(usuarioAlteracao);
            Valido();
        }

        /// <summary>
        ///  Número do Cartão
        /// </summary>
        [Column("numero_cartao"), MaxLength(16), Required]
        public string Numero { get; private set; } = default!;

        [Column("codigo_seguranca"), MaxLength(3)]
        public string? CVV { get; private set; }

        /// <summary>
        ///  Data de expiração do cartão 05/2023
        /// </summary>
        [Column("validade"), MaxLength(7)]
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

        /// <summary>
        /// Indica se o cartão já expirou
        /// </summary>
        [Column("expirado")]
        public bool Expirado { get; private set; }

        private List<FaturaCartao> _faturas  = new List<FaturaCartao>();
        public IReadOnlyList<FaturaCartao> Faturas => _faturas;

        public override bool Valido()
        {
            if (string.IsNullOrEmpty(Nome))
            {
                IncluirAnotacaoErro("Nome deve ser preenchido");
            }

            if (Nome?.Length < 3)
            {
                IncluirAnotacaoErro("Nome deve conter o mínimo de 5 caracteres");
            }

            if (Nome?.Length > 20)
            {
                IncluirAnotacaoErro("Nome deve conter o máximo de 20 caracteres");
            }

            if (!string.IsNullOrEmpty(CVV) && CVV?.Length != 3)
            {
                IncluirAnotacaoErro("Código de segurança inválido");
            }

            if (!Validacoes.ValidadeCartao(Validade))
            {
                Expirado = true;
                IncluirAnotacaoErro("Cartão inválido");
            }

            if (Vencimento <= 0 || Vencimento > 31 ) 
            {
                IncluirAnotacaoErro("Vencimento inválido");
            }

            if (Vencimento <= 0 || DiaMelhorCompra > 31)
            {
                IncluirAnotacaoErro("Vencimento inválido");
            }

            if (Limite <= 0)
            {
                IncluirAnotacaoErro("limite inválido");
            }

            if (string.IsNullOrEmpty(Banco) || Banco.Length > 30)
            {
                IncluirAnotacaoErro("Nome do banco inválido");
            }

            if (!string.IsNullOrEmpty(Banco) && Banco.Length < 3)
            {
                IncluirAnotacaoErro("Nome do banco inválido");
            }

            if (!Validacoes.CartaoCredito(Numero))
            {
                IncluirAnotacaoErro("Número de cartão inválido");
            }

            return base.Valido();
        }
    }
}