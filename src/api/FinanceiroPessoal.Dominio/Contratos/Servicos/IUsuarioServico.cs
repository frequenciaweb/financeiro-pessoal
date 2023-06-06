using FinanceiroPessoal.Dominio.Entidades;

namespace FinanceiroPessoal.Dominio.Contratos.Servicos
{
    public interface IUsuarioServico
    {
        (bool, Usuario) Logar(string usuario, string senha, out string msgErro);        
    }
}
