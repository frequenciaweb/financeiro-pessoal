using FinanceiroPessoal.Dominio.Entidades;
using FinanceiroPessoal.Dominio.Enumeradores;

namespace FinanceiroPessoal.Dominio.Contratos
{
    public interface ICartaoCreditoRepositorio : IRepositorioBase<CartaoCredito>
    {
        CartaoCredito? ObterPorNumero(string numero);
        List<CartaoCredito> ObterPorBanco(string nome);
        List<CartaoCredito> ObterPorBandeira(EnumBandeiraCartao bandeira);
        List<CartaoCredito> ObterCartoesVencidos();
        List<CartaoCredito> ObterPorMelhorData(int numeroDoDia);
    }
}
