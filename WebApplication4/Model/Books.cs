using Microsoft.VisualBasic;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using WebApplication4.Model.Generic;

namespace WebApplication4.Model
{
    [Table("books")]
    public class Books : BaseEntity
    {
        [Column("author")]
        public string Author { get; set; }

        [Column("launch_date")]
        public DateTime LaunchDate { get; set; }

        [Column("price")]
        public decimal Price { get; set; }

        [Column("title")]
        public string Title { get; set; }
    }
}
