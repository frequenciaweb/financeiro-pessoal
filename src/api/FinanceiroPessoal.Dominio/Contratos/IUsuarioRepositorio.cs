using FinanceiroPessoal.Dominio.Entidades;

namespace FinanceiroPessoal.Dominio.Contratos
{
    public interface IUsuarioRepositorio : IRepositorioBase<Usuario>
    {
        bool Logar(string usuario, string senha);
        bool TrocarSenha(string senhaAtual, string novaSenha, Guid usuarioID, out string msgErro);
    }
}
