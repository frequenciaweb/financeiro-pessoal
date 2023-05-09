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
            return Context.Usuarios.Any(x => x.Email == usuario && x.Senha == senha); 
        }

        public bool TrocarSenha(string senhaAtual, string novaSenha, Guid usuarioID)
        {
            var usuario = Context.Usuarios.Find(usuarioID);
            if (usuario != null) 
            {   
                usuario.TrocarSenha(senhaAtual, novaSenha);
                if (usuario.Valido)
                {
                    Context.Usuarios.Update(usuario);
                }
                return usuario.Valido;
            }

            return false;
        }
    }
}
