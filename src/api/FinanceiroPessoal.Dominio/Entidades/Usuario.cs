﻿using FinanceiroPessoal.Dominio.Util;
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
        }

        [Column("nome"), MaxLength(60), Required]
        public string Nome { get; private set; } = default!;

        [Column("email"), MaxLength(255), Required]
        public string Email { get; private set; } = default!;

        [Column("senha"), MaxLength(255), Required]
        public string Senha { get; private set; } = default!;
    }
}
