using FinanceiroPessoal.Dominio.Contratos.Repositorios;
using FinanceiroPessoal.Dominio.Contratos.Servicos;
using FinanceiroPessoal.Dominio.Entidades;
using FinanceiroPessoal.Dominio.ViewModels.Entrada;
using FinanceiroPessoal.Infraestrutura.EF;

namespace FinanceiroPessoal.Aplicacao.Servicos
{
    public class CartaoCreditoServico : BaseServico, ICartaoCreditoServico
    {
        private readonly ICartaoCreditoRepositorio _cartaoCreditorepositorio;

        public CartaoCreditoServico(FinanceiroPessoalContext contexto, ICartaoCreditoRepositorio cartaoCreditorepositorio) : base(contexto)
        {
            _cartaoCreditorepositorio = cartaoCreditorepositorio;
        }

        public (bool, string) Alterar(VMCartaoCreditoAlterar cartaoCredito)
        {
            CartaoCredito cartao = cartaoCredito;

            if (cartao.Valido())
            {
                _cartaoCreditorepositorio.Alterar(cartao);
                Commit();
                return (true, "Dados Alterados com sucesso");
            }
            else
            {
                return (false, cartao.LerAnotacoesErro());
            }
        }

        public (bool, string) Excluir(VMCartaoCreditoExcluir cartaoCredito)
        {
            var cartao = _cartaoCreditorepositorio.Obter(cartaoCredito.ID);
            if (cartao != null)
            {
                _cartaoCreditorepositorio.Excluir(cartao);
                Commit();
                return (true, "Dados de cartão excluidos com sucesso");
            }
            else
            {
                return (false, "Dados de cartão não encontrados");
            }
        }

        public (bool, string, CartaoCredito?) Incluir(VMCartaoCreditoIncluir cartaoCredito)
        {
            CartaoCredito cartao = cartaoCredito;

            if (cartao.Valido())
            {
                if (!_cartaoCreditorepositorio.Existe(cartaoCredito.Numero))
                {
                    cartao = _cartaoCreditorepositorio.Incluir(cartao);
                    Commit();
                    return (true, "Dados de cartão incluidos com sucesso", cartao);
                }
                else
                {
                    return (false, "Cartão já cadastrado", null);
                }
            }
            else
            {
                return (false, cartao.LerAnotacoesErro(), null);
            }
        }
    }
}
