using FinanceiroPessoal.Dominio.Contratos;
using FinanceiroPessoal.Dominio.Entidades;
using FinanceiroPessoal.Infraestrutura.EF;

namespace FinanceiroPessoal.Infraestrutura.Repositorios
{
    public class UsuarioRepositorio : RepositorioBase<Usuario>, IUsuarioRepositorio
    {
        public UsuarioRepositorio(FinanceiroPessoalContext context) : base(context)
        {
        }

        public bool Logar(string usuario, string senha)
        {
            return Context.Usuarios.Any(x => x.Email == usuario && x.Senha == senha && !x.Deletado); 
        }

        public bool TrocarSenha(string senhaAtual, string novaSenha, Guid usuarioID, out string msgErro)
        {
            msgErro = string.Empty;
            var usuario = Context.Usuarios.Find(usuarioID);
            if (usuario != null) 
            {   
                usuario.TrocarSenha(senhaAtual, novaSenha);
                var resultado = usuario.Valido();
                if (resultado)
                {
                    Context.Usuarios.Update(usuario);
                }
                else
                {
                    msgErro = usuario.LerAnotacoesErro();
                }
                return resultado;
            }
            else
            {
                msgErro = "Usuário não encontrado";
            }

            return false;
        }
    }
}
