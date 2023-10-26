using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication4.ORM.Entity
{
    public class BaseEntity
    {
        [Column("id")]
        public long Id { get; set; }
    }
}
