using FinanceiroPessoal.Dominio.Contratos.Repositorios;
using FinanceiroPessoal.Dominio.Entidades;
using FinanceiroPessoal.Infraestrutura.EF;

namespace FinanceiroPessoal.Infraestrutura.Repositorios
{
    public class UsuarioRepositorio : RepositorioBase<Usuario>, IUsuarioRepositorio
    {
        public UsuarioRepositorio(FinanceiroPessoalContext context) : base(context)
        {
        }

        public bool ExistePorEmail(string email)
        {
           return Context.Usuarios.Any(a => a.Email == email);  
        }

        public List<Usuario> ListarAtivos()
        {
            return Context.Usuarios.Where(x => x.Ativo).ToList();
        }

        public Usuario? Logar(string usuario, string senha)
        {
            return Context.Usuarios.FirstOrDefault(x => x.Email == usuario && x.Senha == senha && !x.Deletado); 
        }

        public void RegistrarAcesso(Guid usuarioID)
        {
            Context.Acessos.Add(new Acesso(usuarioID));
        }

        public bool TrocarSenha(string senhaAtual, string novaSenha, Guid usuarioID, out string msgErro)
        {
            msgErro = string.Empty;
            var usuario = Context.Usuarios.FirstOrDefault(x => x.ID == usuarioID && !x.Deletado);
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
