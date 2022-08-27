using ClassLibraryForShoppingmall.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryForShoppingmall.ShoppingDbContext
{
    public class ShoppingMallDbContext : DbContext
    {
                public DbSet<Shopping> Malls { get; set; }
                public ShoppingMallDbContext()
                {

                }
                public ShoppingMallDbContext(DbContextOptions options) : base(options)
                {

                }
                protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
                {
                    optionsBuilder.UseSqlServer("Data Source=LAPTOP-MIL5M1L9;Initial Catalog=ShoppingMalls;Integrated Security=True");
                }
                protected override void OnModelCreating(ModelBuilder builder)
                {
                    
            builder.Entity<Shopping>(entity => entity.HasIndex(e => e.ShoppingMallName).IsUnique());
            builder.Entity<Shopping>().Property(e => e.ShoppingMallName).HasColumnType("VARCHAR").HasMaxLength(50);
            builder.Entity<Shopping>().Property(e => e.ShoppingMallCity).HasColumnType("VARCHAR").HasMaxLength(50);
            builder.Entity<Shopping>().Property(e => e.ShoppingMallState).HasColumnType("VARCHAR").HasMaxLength(50);
        }
            
        
    }
}
