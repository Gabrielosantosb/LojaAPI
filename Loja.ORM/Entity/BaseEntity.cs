using System.ComponentModel.DataAnnotations.Schema;

namespace Loja.ORM.Entity
{
    public class BaseEntity
    {
        [Column("id")]
        public long Id { get; set; }
    }
}
