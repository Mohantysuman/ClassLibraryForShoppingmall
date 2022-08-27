using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ShoppingMallMVC.Models;

namespace ShoppingMallMVC.Data
{
    public class ShoppingMallMVCContext : DbContext
    {
        public ShoppingMallMVCContext (DbContextOptions<ShoppingMallMVCContext> options)
            : base(options)
        {
        }

        public DbSet<ShoppingMallMVC.Models.ShoppingMallModel> ShoppingMallModel { get; set; } = default!;
    }
}
