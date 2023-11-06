using Loja.ORM.Entity;
using Loja.Services.Services.PersonServices.Models;
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
        public DbSet<User> Users { get; set; }

    }
}
