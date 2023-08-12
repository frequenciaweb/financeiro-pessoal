namespace FinanceiroPessoal.Dominio.ViewModel
{
    public class UsuarioIncluido
    {
        public Guid Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Senha { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public bool EhAdmin { get; set; } = false;
    }
}
