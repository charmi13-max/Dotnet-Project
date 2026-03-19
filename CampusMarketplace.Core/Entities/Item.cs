namespace CampusMarketplace.Core.Entities;

public class Item
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public string? ImageUrl { get; set; }

    // FK to User (string because IdentityUser uses string Id by default)
    public string UserId { get; set; } = string.Empty;

    // FK to Category
    public int CategoryId { get; set; }
    public Category? Category { get; set; }
}
