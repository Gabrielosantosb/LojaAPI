using Loja.ORM.Entity;
using Microsoft.EntityFrameworkCore;

namespace Loja.ORM
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
