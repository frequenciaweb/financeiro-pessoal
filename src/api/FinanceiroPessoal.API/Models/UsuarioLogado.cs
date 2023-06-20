using FinanceiroPessoal.Dominio.Entidades;

namespace FinanceiroPessoal.API.Models
{
    public class UsuarioLogado
    {
        public UsuarioLogado(Usuario usuario, string token)
        {
            ID = usuario.ID;
            Nome = usuario.Nome;
            Email = usuario.Email;
            Acesso = DateTime.Now;
            Token = token;
        }

        public Guid ID { get; private set; }
        public string Nome { get; private set; } = default!;
        public string Email { get; private set; } = default!;
        public DateTime Acesso { get; private set; } 
        public string Token { get; private set; }
    }
}
