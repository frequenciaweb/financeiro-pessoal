using FinanceiroPessoal.Dominio.Entidades;

namespace FinanceiroPessoal.API.Models
{
    public class UsuarioLogado
    {
        public UsuarioLogado(Usuario usuario)
        {
            ID = usuario.ID;
            Nome = usuario.Nome;
            Email = usuario.Email;
            Acesso = DateTime.Now;
        }
        public Guid ID { get; private set; }
        public string Nome { get; private set; } = default!;
        public string Email { get; private set; } = default!;
        public DateTime Acesso { get; private set; } 
    }
}
