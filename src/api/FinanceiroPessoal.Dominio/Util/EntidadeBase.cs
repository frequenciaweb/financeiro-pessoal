﻿using FinanceiroPessoal.Dominio.Entidades;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinanceiroPessoal.Dominio.Util
{
    public abstract class EntidadeBase : EntidadeValidacao
    {
        public EntidadeBase() { }

        private void GerarRegistro(Guid id, DateTime criadoEm, DateTime? atualizadoEm, DateTime? deletadoEm, bool deletado, bool atualizado, string usuarioInclusao, string? usuarioAlteracao, string? usuarioDelecao, bool ativo)
        {
            ID = id;
            CriadoEm = criadoEm;
            AtualizadoEm = atualizadoEm;
            DeletadoEm = deletadoEm;
            Deletado = deletado;
            Atualizado = atualizado;
            UsuarioInclusao = usuarioInclusao;
            UsuarioAlteracao = usuarioAlteracao;
            UsuarioDelecao = usuarioDelecao;
            Ativo = ativo;

            if (string.IsNullOrWhiteSpace(usuarioInclusao))
            {
                IncluirAnotacaoErro("Usuário da operação deve ser informado");
            }

            if (!string.IsNullOrWhiteSpace(usuarioInclusao) && usuarioInclusao.Length > 60)
            {
                IncluirAnotacaoErro("Nome do usuário da operação não pode ser maior que 60 caracteres");
            }

            if (!string.IsNullOrWhiteSpace(usuarioInclusao) && usuarioInclusao.Length < 10)
            {
                IncluirAnotacaoErro("Nome do usuário da operação não pode ser menor que 10 caracteres");
            }

        }

        public EntidadeBase(Guid id, string usuarioInclusao)
        {
            GerarRegistro(id,
                criadoEm: DateTime.Now,
                atualizadoEm: null,
                deletadoEm: null,
                deletado: false,
                atualizado: false,
                usuarioInclusao: usuarioInclusao,
                usuarioAlteracao: null,
                usuarioDelecao: null,
                ativo: true);
        }

        public EntidadeBase(string usuarioInclusao)
        {
            GerarRegistro(Guid.NewGuid(),
               criadoEm: DateTime.Now,
               atualizadoEm: null,
               deletadoEm: null,
               deletado: false,
               atualizado: false,
               usuarioInclusao: usuarioInclusao,
               usuarioAlteracao: null,
               usuarioDelecao: null,
               ativo: true);
        }

        protected EntidadeBase(Guid id, DateTime criadoEm, DateTime? atualizadoEm, DateTime? deletadoEm,
            bool deletado, bool atualizado, string usuarioInclusao, string usuarioAlteracao, string? usuarioDelecao, bool ativo)
        {
            GerarRegistro(id,
                 criadoEm: criadoEm,
                 atualizadoEm: atualizadoEm,
                 deletadoEm: deletadoEm,
                 deletado: deletado,
                 atualizado: atualizado,
                 usuarioInclusao: usuarioInclusao,
                 usuarioAlteracao: usuarioAlteracao,
                 usuarioDelecao: usuarioDelecao,
                 ativo: ativo);
        }

        [Column("id")]
        public Guid ID { get; private set; }

        [Column("criado_em")]
        [Required]
        public DateTime CriadoEm { get; private set; }

        [Column("atualizado_em")]
        public DateTime? AtualizadoEm { get; private set; }

        [Column("deletado_em")]
        public DateTime? DeletadoEm { get; private set; }

        [Column("deletado")]
        [Required]
        public bool Deletado { get; private set; }

        [Column("atualizado")]
        [Required]
        public bool Atualizado { get; private set; }

        [Column("usuario_inclusao")]
        [MaxLength(60)]
        [Required]
        public string UsuarioInclusao { get; private set; } = default!;

        [Column("usuario_alteracao")]
        [MaxLength(60)]
        public string? UsuarioAlteracao { get; private set; } = default!;

        [Column("usuario_delecao")]
        [MaxLength(60)]
        public string? UsuarioDelecao { get; private set; }

        [Column("ativo")]
        [Required]
        public bool Ativo { get; private set; }

        public void IncluirInformacoesAlteracao(string usuario)
        {

            if (!string.IsNullOrWhiteSpace(usuario) && usuario.Length > 60)
            {
                IncluirAnotacaoErro("Nome do usuário da operação não pode ser maior que 60 caracteres");
            }

            if (!string.IsNullOrWhiteSpace(usuario) && usuario.Length < 10)
            {
                IncluirAnotacaoErro("Nome do usuário da operação não pode ser menor que 10 caracteres");
            }

            if (string.IsNullOrWhiteSpace(usuario))
            {
                IncluirAnotacaoErro("Usuário de alteração não foi informado");
            }
            else
            {
                UsuarioAlteracao = usuario;
                Atualizado = true;
                AtualizadoEm = DateTime.Now;
            }
        }

        public bool ValidarUsuarioInclusao()
        {
            if (!string.IsNullOrWhiteSpace(UsuarioInclusao) && UsuarioInclusao.Length > 60)
            {
                IncluirAnotacaoErro("Nome do usuário da operação não pode ser maior que 60 caracteres");
                return false;
            }

            if (!string.IsNullOrWhiteSpace(UsuarioInclusao) && UsuarioInclusao.Length < 10)
            {
                IncluirAnotacaoErro("Nome do usuário da operação não pode ser menor que 10 caracteres");
                return false;
            }

            if (string.IsNullOrWhiteSpace(UsuarioInclusao))
            {
                IncluirAnotacaoErro("Usuário de inclusão não foi informado");
                return false;
            }

            return true;

        }

        public void IncluirInformacoesUsuarioInclusao(string usuario)
        {   
            UsuarioInclusao = usuario;
            CriadoEm = DateTime.Now;

            ValidarUsuarioInclusao();

        }
        public void DeletarRegistroLogico()
        {
            Deletado = true;
            DeletadoEm = DateTime.Now;
        }

        public void RemoverDeletado()
        {
            Deletado = false;
            DeletadoEm = null;
        }
    }
}