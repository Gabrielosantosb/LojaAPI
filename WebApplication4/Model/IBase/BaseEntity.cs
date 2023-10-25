using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication4.Model.Generic
{
    public class BaseEntity
    {
        [Column("id")]
        public long Id { get; set; }
    }
}
