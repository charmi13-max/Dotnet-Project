using CampusMarketplace.Core.Entities;
using CampusMarketplace.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CampusMarketplace.Infrastructure.Data;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<Item> Items { get; set; }
    public DbSet<Category> Categories { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        // Configure relationships
        builder.Entity<Item>()
            .HasOne(i => i.Category)
            .WithMany(c => c.Items)
            .HasForeignKey(i => i.CategoryId);
        
        // Setup a foreign key relationship with ApplicationUser even though Item is in Core and ApplicationUser is in Infrastructure.
        // We do this by mapping the UserId string property to the ApplicationUser.
        builder.Entity<Item>()
            .HasOne<ApplicationUser>()
            .WithMany()
            .HasForeignKey(i => i.UserId)
            .IsRequired();
            
        // Setup initial default categories
        builder.Entity<Category>().HasData(
            new Category { Id = 1, Name = "Textbooks", Description = "Used and new textbooks" },
            new Category { Id = 2, Name = "Electronics", Description = "Laptops, phones, accessories" },
            new Category { Id = 3, Name = "Furniture", Description = "Desks, chairs, beds" },
            new Category { Id = 4, Name = "Clothing", Description = "University merch and everyday clothes" },
            new Category { Id = 5, Name = "Miscellaneous", Description = "Anything else" }
        );
    }
}
