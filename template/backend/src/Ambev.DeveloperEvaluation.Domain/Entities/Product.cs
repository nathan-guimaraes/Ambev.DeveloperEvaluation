using Ambev.DeveloperEvaluation.Domain.Common;

namespace Ambev.DeveloperEvaluation.Domain.Entities;

public class Product : BaseEntity, IProduct
{
    public string Title { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public string Description { get; set; } = string.Empty;
    public string Category { get; set; } = string.Empty;
    public string Image { get; set; } = string.Empty;
    public Rating Rating { get; set; } = new();


    public Product() { }

    public Product(string title, decimal price, string description, string category, string image, Rating rating)
    {
        Title = title;
        Price = price;
        Description = description;
        Category = category;
        Image = image;
        Rating = rating;
    }

    string IProduct.Id => Id.ToString();
}

public interface IProduct
{
    public string Id { get; }
    public string Title { get; }
    public decimal Price { get; }
    public string Description { get; }
    public string Category { get; }
    public string Image { get; }
    public Rating Rating { get; }
}

public record Rating
{
    public decimal Rate { get; set; }
    public int Count { get; set; }
}