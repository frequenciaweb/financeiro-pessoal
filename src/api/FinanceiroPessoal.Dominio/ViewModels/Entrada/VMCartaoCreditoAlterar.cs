using FinanceiroPessoal.Dominio.Entidades;
using FinanceiroPessoal.Dominio.Enumeradores;
using System.ComponentModel;

namespace FinanceiroPessoal.Dominio.ViewModels.Entrada
{
    public class VMCartaoCreditoAlterar
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

        public static implicit operator CartaoCredito(VMCartaoCreditoAlterar vm)
        {
            return new CartaoCredito(vm.Nome,
                     vm.Numero,
                     vm.Cvv,
                     vm.Validade,
                     vm.Vencimento,
                     vm.DiaMelhorCompra,
                     vm.Limite,
                     vm.Banco,
                     vm.Bandeira,
                     vm.DonoCartaoUsuarioID,
                     vm.UsuarioInclusao);
        }

    }
}
