using Ambev.DeveloperEvaluation.Domain.ValueObjects;

namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale;

public class CreateSaleResult
{
    public string Id { get; set; }
    public long Number { get; set; }
    public Guid UserId { get; set; }
    public DateTime SaleDate { get; set; }
    public List<SaleItem> Items { get; set; } = [];
    public decimal TotalSaleAmount { get; set; }
    public bool IsCanceled { get; set; }
    public decimal TotalSaleDiscount { get; set; }
    public string Branch { get; set; }
}
