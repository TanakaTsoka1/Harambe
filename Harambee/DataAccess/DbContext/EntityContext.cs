using Harambee.DataAccess.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Harambee.DataAccess.DbContext
{
    public class EntityContext : IdentityDbContext
    {
        // Cart Tables
        public DbSet<Customer> Customers { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Bundle> Bundles { get; set; }


        public EntityContext(DbContextOptions<EntityContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            // One Category has many Products
            builder.Entity<Product>()
                .HasOne<Category>(x => x.Category)
                .WithMany(x => x.Products)
                .HasForeignKey(x => x.CategoryID)
                .OnDelete(DeleteBehavior.Cascade);

            // One Bundle has many Products
            builder.Entity<Product>()
                .HasOne<Bundle>(x => x.Bundle)
                .WithMany(x => x.Products)
                .HasForeignKey(x => x.BundleID)
                .OnDelete(DeleteBehavior.Cascade);

            base.OnModelCreating(builder);
        }
    }
}
