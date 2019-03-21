using System;
using Microsoft.EntityFrameworkCore;

namespace Erp_Biscuiterie_Back.Business.Models
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        {

        }

        public DbSet<User> User { get; set; }
        public DbSet<Role> Role { get; set; }
    }
}
