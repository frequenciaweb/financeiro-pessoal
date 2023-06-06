using FinanceiroPessoal.Dominio.Entidades;

namespace FinanceiroPessoal.Dominio.Contratos.Repositorios
{
    public interface IUsuarioRepositorio : IRepositorioBase<Usuario>
    {
        Usuario? Logar(string login, string senha);
        bool TrocarSenha(string senhaAtual, string novaSenha, Guid usuarioID, out string msgErro);
        void RegistrarAcesso(Guid usuarioID);
    }
}
