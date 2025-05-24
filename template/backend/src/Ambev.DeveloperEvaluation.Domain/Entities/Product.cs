using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Contracts;
using Ambev.DeveloperEvaluation.Domain.ValueObjects;

namespace Ambev.DeveloperEvaluation.Domain.Entities;

public class Product : BaseEntity, IProduct
{
    public string Title { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public string Description { get; set; } = string.Empty;
    public string Category { get; set; } = string.Empty;
    public string Image { get; set; } = string.Empty;
    public Rating Rating { get; set; } = new();


    //public Product() { }

    //public Product(string title, decimal price, string description, string category, string image, Rating rating)
    //{
    //    Title = title;
    //    Price = price;
    //    Description = description;
    //    Category = category;
    //    Image = image;
    //    Rating = rating;
    //}

    string IProduct.Id => Id.ToString();
}
