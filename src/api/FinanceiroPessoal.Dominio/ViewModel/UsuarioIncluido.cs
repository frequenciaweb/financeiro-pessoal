using FinanceiroPessoal.Dominio.Entidades;

namespace FinanceiroPessoal.Dominio.ViewModel
{
    public class UsuarioIncluido
    {
        public Guid Id { get; set; }
        public string Nome { get; set; } = string.Empty;        
        public string Email { get; set; } = string.Empty;
        public bool EhAdmin { get; set; } = false;

        public static UsuarioIncluido MapearEntidadeUsuario(Usuario entidade)
        {
            return new UsuarioIncluido() 
            { 
                 EhAdmin = entidade.EhAdmin,
                 Email = entidade.Email,
                 Id  = entidade.ID,
                 Nome = entidade.Nome,  
            };
        }

    }
}
