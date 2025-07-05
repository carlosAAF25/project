namespace OnlineStore
{
    using System.Collections.Generic;
    using Microsoft.EntityFrameworkCore;
    using OnlineStore.Models;

    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        public DbSet<Product> Products => Set<Product>();
    }
}
