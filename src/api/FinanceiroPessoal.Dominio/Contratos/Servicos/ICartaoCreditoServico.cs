using FinanceiroPessoal.Dominio.Entidades;
using FinanceiroPessoal.Dominio.ViewModels.Entrada;

namespace FinanceiroPessoal.Dominio.Contratos.Servicos
{
    public interface ICartaoCreditoServico : IBaseServico
    {
        (bool, string, CartaoCredito?) Incluir(VMCartaoCreditoIncluir cartaoCredito);
        (bool, string ) Alterar(VMCartaoCreditoAlterar cartaoCredito);
        (bool, string ) Excluir(VMCartaoCreditoExcluir cartaoCredito);
    }
}

