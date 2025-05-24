using Ambev.DeveloperEvaluation.Domain.ValueObjects;

namespace Ambev.DeveloperEvaluation.Domain.Contracts;

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
