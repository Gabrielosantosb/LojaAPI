using Microsoft.EntityFrameworkCore;
using WebApplication4.ORM.Entity;

namespace WebApplication4.ORM
{
    public class MySQLContext : DbContext
    {
        public MySQLContext()
        {

        }

        public MySQLContext(DbContextOptions<MySQLContext> options) : base(options)
        {

        }

        public DbSet<Person> Persons { get; set; }
        public DbSet<Books> Books { get; set; }

    }
}
