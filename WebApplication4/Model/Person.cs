using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication4.Model
{
    [Table("person")]
    public class Person
    {
        //public long Id { get; set; } 
        //public string FirstName { get; set; }
        //public string LastName { get; set; }
        //public string Address { get; set; }
        //public string Gender { get; set; }


        [Column("id")]
        public long Id { get; set; }
        [Column("first_name")]
        public string FirstName { get; set; }
        [Column("last_name")]
        public string LastName { get; set; }
        [Column("description")]
        public string Description { get; set; }



    }
}
