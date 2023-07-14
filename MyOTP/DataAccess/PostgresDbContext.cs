using System.Xml;
using Microsoft.EntityFrameworkCore;
using MyOTP.Models;

namespace MyOTP.DataAccess
{
    public class PostgresDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        // Diğer DbSet'leri buraya ekleyin

        public PostgresDbContext(DbContextOptions<PostgresDbContext> options)
            : base(options)
        {
        }
    }
}
