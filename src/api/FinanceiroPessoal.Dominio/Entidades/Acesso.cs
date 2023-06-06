using System.ComponentModel.DataAnnotations.Schema;

namespace FinanceiroPessoal.Dominio.Entidades
{
    [Table("usuario_acessos")]
    public class Acesso
    {
        public Acesso(Guid usuarioID)
        {
            Em = DateTime.Now;
            ID = Guid.NewGuid();
            UsuarioID = usuarioID;
        }

        [Column("id")]
        public Guid ID { get; private set; }

        [Column("usuario_id")]
        public Guid UsuarioID { get; private set; }

        [Column("em")]
        public DateTime Em { get; private set; }
    }
}
