using FinanceiroPessoal.Dominio.Entidades;
using FinanceiroPessoal.Utilitarios.Util;

namespace FinanceiroPessoal.API.Models
{
    public class UsuarioIncluir
    {
        public string Nome { get; set; } = string.Empty;
        public string Senha { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public bool EhAdmin { get; set; } = false;

        public static implicit operator Usuario(UsuarioIncluir incluir)
        {
            return new Usuario(incluir.Nome.ToLower(),
                incluir.Email.ToLower(),
                Seguranca.HashMd5(incluir.Senha),
                "",
                incluir.EhAdmin);            
        }
    }
}
