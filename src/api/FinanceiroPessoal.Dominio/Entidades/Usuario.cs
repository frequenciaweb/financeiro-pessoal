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

        public Usuario(string nome, string email, string senha, string usuarioInclusao):base(usuarioInclusao) 
        {
            Nome = nome;
            Email = email;
            Senha = senha;

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

        /// <summary>
        /// Metodo responsavel por alterar o valor da senha na entidade de usuário
        /// </summary>
        /// <param name="senhaAtual">Senha atual</param>
        /// <param name="novaSenha">nova senha</param>
        public void TrocarSenha(string senhaAtual, string novaSenha)
        {

            if (!Validacoes.Senha(novaSenha))
            {
                IncluirAnotacaoErro("Senha inválida");
            }
            else
            {
                novaSenha = Seguranca.HashMd5(novaSenha);
            }

            senhaAtual = Seguranca.HashMd5(senhaAtual);

            if (Senha == senhaAtual)
            {
                Senha = novaSenha;
            }
            else
            {
                IncluirAnotacaoErro("Senha digitada não confere com a senha atual");
            }
        }

        public override bool Valido()
        {

            if (string.IsNullOrEmpty(Nome))
            {
                IncluirAnotacaoErro("Nome deve ser preenchido");
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
    }
}
