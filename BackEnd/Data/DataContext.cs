using FullStack.Models;
using Microsoft.EntityFrameworkCore;

namespace FullStack.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) 
       : base(options) {}

       public DbSet<User> users { get; set; }
       public DbSet<UserAddress> userAddresses { get; set; }
    }
}