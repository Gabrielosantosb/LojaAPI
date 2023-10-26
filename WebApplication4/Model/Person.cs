using System.ComponentModel.DataAnnotations.Schema;
using WebApplication4.Model.Generic;

namespace WebApplication4.Model
{
    [Table("person")]
    public class Person : BaseEntity
    {
       
        [Column("first_name")]
        public string FirstName { get; set; }
        [Column("last_name")]
        public string LastName { get; set; }
        [Column("description")]
        public string Description { get; set; }



    }
}
