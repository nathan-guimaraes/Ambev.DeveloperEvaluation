namespace Ambev.DeveloperEvaluation.Domain.ValueObjects;

public class SaleItem
{
    public Guid ProductId { get; set; }
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal TotalAmountWithDiscount { get; set; }
    public decimal TotalSaleItemAmount { get; set; }
}
