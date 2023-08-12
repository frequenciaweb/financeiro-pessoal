using FinanceiroPessoal.Dominio.Util;
using FinanceiroPessoal.Utilitarios.Util;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinanceiroPessoal.Dominio.Entidades
{
    [Table("usuarios")]
    public class Usuario : EntidadeBase
    {
        public Usuario(){}

        public Usuario(Guid id, string nome, string email, string senha, string usuarioInclusao, bool admin) : base(id, usuarioInclusao)
        {            
            GerarUsuario(id, nome, email, senha, admin);
        }
        public Usuario(string nome, string email, string senha, string usuarioInclusao, bool admin):base(usuarioInclusao) 
        {
            GerarUsuario(Guid.NewGuid(), nome, email, senha, admin);
        }

        private void GerarUsuario(Guid id, string nome, string email, string senha, bool admin)
        {           
            Nome = nome;
            Email = email;
            Senha = senha;
            EhAdmin = admin;

            if (!Validacoes.Senha(Senha))
            {
                IncluirAnotacaoErro("Senha inválida");
            }
            else
            {
                Senha = Seguranca.HashMd5(Senha);
            }
        }

        [Column("nome"), MaxLength(60), Required]
        public string Nome { get; private set; } = default!;

        [Column("email"), MaxLength(255), Required]
        public string Email { get; private set; } = default!;

        [Column("senha"), MaxLength(255), Required]
        public string Senha { get; private set; } = default!;

        [Column("admin"), Required]
        public bool EhAdmin { get; private set; } = false;


        /// <summary>
        /// Metodo responsavel por alterar o valor da senha na entidade de usuário
        /// </summary>
        /// <param name="senhaAtual">Senha atual</param>
        /// <param name="novaSenha">nova senha</param>
        public (bool resultado, string msgErro) TrocarSenha(string senhaAtual, string novaSenha )
        {
            string mensagem = "";
            if (!Validacoes.Senha(novaSenha))
            {
                mensagem = "Senha inválida";
                IncluirAnotacaoErro(mensagem);
                return (false, mensagem);
            }
            else
            {
                novaSenha = Seguranca.HashMd5(novaSenha);
            }

            senhaAtual = Seguranca.HashMd5(senhaAtual);

            if (Senha == senhaAtual)
            {
                Senha = novaSenha;
                return (true, string.Empty);
            }
            else
            {
                mensagem = "Senha digitada não confere com a senha atual";
                IncluirAnotacaoErro(mensagem);
                return (false, mensagem);
            }
        }

        public override bool Valido()
        {
            LimparMensagensErro();

            if (string.IsNullOrEmpty(Nome))
            {
                IncluirAnotacaoErro("Nome de usuário deve ser preenchido");
            }

            if (Nome?.Length < 10)
            {
                IncluirAnotacaoErro("Nome de usuário deve conter o mínimo de 10 caracteres");
            }

            if (Nome?.Length > 60)
            {
                IncluirAnotacaoErro("Nome deve conter o máximo de 60 caracteres");
            }

            if (!Validacoes.Email(Email))
            {
                IncluirAnotacaoErro("E-mail inválido");
            }

            return base.Valido();
        }

        public void TrocarNome(string nome)
        {
            Nome = nome.Trim().ToUpper();
            Valido();
        }

        public void TrocarEmail(string email)
        {
            Email = email;
            Valido();
        }
    }
}
