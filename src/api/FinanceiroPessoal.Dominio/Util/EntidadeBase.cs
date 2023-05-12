using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinanceiroPessoal.Dominio.Util
{
    public abstract class EntidadeBase : EntidadeValidacao
    {
        public EntidadeBase() { }

        public EntidadeBase(string usuarioInclusao)
        {
            ID = Guid.NewGuid();
            CriadoEm = DateTime.Now;
            AtualizadoEm = null;
            DeletadoEm = null;
            Deletado = false;
            Atualizado = false;
            UsuarioInclusao = usuarioInclusao;
            Ativo = true;
        }

        protected EntidadeBase(Guid id, DateTime criadoEm, DateTime? atualizadoEm, DateTime? deletadoEm, bool deletado, bool atualizado, string usuarioInclusao, string usuarioAlteracao, string? usuarioDelecao, bool ativo)
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
        public string UsuarioAlteracao { get; private set; } = default!;

        [Column("usuario_delecao")]
        [MaxLength(60)]
        public string? UsuarioDelecao { get; private set; }

        [Column("ativo")]
        [Required]
        public bool Ativo { get; private set; }
    }
}