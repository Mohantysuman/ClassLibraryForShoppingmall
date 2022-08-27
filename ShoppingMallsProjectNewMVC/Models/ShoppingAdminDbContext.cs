using Microsoft.EntityFrameworkCore;

namespace ShoppingMallsProjectNewMVC.Models
{
    public class ShoppingAdminDbContext : DbContext
    {
        public DbSet<AdminModel> ShoppingMallModels { get; set; }
        public ShoppingAdminDbContext()
        {

        }
        public ShoppingAdminDbContext(DbContextOptions options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=LAPTOP-MIL5M1L9;Initial Catalog=ShoppingMalls;Integrated Security=True");
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder.Entity<AdminModel>(entity => entity.HasIndex(e => e.Email).IsUnique());
            builder.Entity<AdminModel>().Property(e => e.Password).HasColumnType("VARCHAR").HasMaxLength(10);
            builder.Entity<AdminModel>().Property(e => e.PanNumber).HasColumnType("VARCHAR").HasMaxLength(10);
            builder.Entity<AdminModel>().Property(e => e.RoleName).HasColumnType("VARCHAR").HasMaxLength(10);
            builder.Entity<AdminModel>().Property(e => e.ConfirmPassword).HasColumnType("VARCHAR").HasMaxLength(10);
            builder.Entity<AdminModel>().Property(e => e.Status).HasColumnType("VARCHAR").HasMaxLength(10);
        }
    }
}
