using CartPro.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace CartPro.DAL
{
    public class CartProDbContext : DbContext
    {
        public CartProDbContext(DbContextOptions options) : base(options)
        {
            
        }
        public DbSet<Role> Roles { get; set; }

        public DbSet<Catagory> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }

        public DbSet<Register> Register { get; set; }
    }
}
