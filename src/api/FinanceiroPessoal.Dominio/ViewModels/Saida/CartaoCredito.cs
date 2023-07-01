using FinanceiroPessoal.Dominio.Enumeradores;

namespace FinanceiroPessoal.Dominio.ViewModels.Saida
{
    public class CartaoCredito
    {
        public Guid ID { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Numero { get; set; } = string.Empty;
        public string? Cvv { get; set; }
        public string Validade { get; set; } = string.Empty;
        public int Vencimento { get; set; }
        public int DiaMelhorCompra { get; set; }
        public decimal Limite { get; set; }
        public string Banco { get; set; } = string.Empty;
        public EnumBandeiraCartao Bandeira { get; set; }
        public Guid DonoCartaoUsuarioID { get; set; }
        public string UsuarioInclusao { get; set; } = string.Empty;
    }
}
