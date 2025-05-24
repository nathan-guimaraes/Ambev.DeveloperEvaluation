namespace Ambev.DeveloperEvaluation.Domain.ValueObjects;
public record CartItemSale
{
    public Guid ProductId { get; set; }
    public int Quantity { get; set; }
}