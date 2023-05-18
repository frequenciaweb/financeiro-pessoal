using FinanceiroPessoal.Dominio.Contratos;
using FinanceiroPessoal.Dominio.Entidades;
using FinanceiroPessoal.Dominio.Enumeradores;
using FinanceiroPessoal.Infraestrutura.EF;

namespace FinanceiroPessoal.Infraestrutura.Repositorios
{
    public class CartaoCreditoRepositorio : RepositorioBase<CartaoCredito>, ICartaoCreditoRepositorio
    {
        public CartaoCreditoRepositorio(FinanceiroPessoalContext context) : base(context)
        {
        }

        public List<CartaoCredito> ObterCartoesVencidos()
        {
            return Context.Cartoes
                .ToList()
                .Where(x => !x.Valido() && x.Expirado)
                .ToList();
        }

        public List<CartaoCredito> ObterPorBanco(string nome)
        {
            return Context.Cartoes
                 .Where(x => x.Banco.Contains(nome))
                 .ToList();
        }

        public List<CartaoCredito> ObterPorBandeira(EnumBandeiraCartao bandeira)
        {
            return Context.Cartoes
                .Where(x => x.Bandeira == bandeira)
                .ToList();
        }

        public List<CartaoCredito> ObterPorMelhorData(int numeroDoDia)
        {
            return Context.Cartoes
                .Where(x => x.DiaMelhorCompra >= numeroDoDia)
                .ToList();
        }

        public CartaoCredito? ObterPorNumero(string numero)
        {
            return Context.Cartoes
              .FirstOrDefault(x => x.Numero.Contains(numero));
        }
    }
}
