using Ambev.DeveloperEvaluation.Domain.ValueObjects;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSale;

public class CreateSaleResponse
{
    public Guid Id { get; set; }
    public long Number { get; }
    public Guid UserId { get; }
    public DateTime SaleDate { get; }
    public List<SaleItem> Items { get; } = [];
    public decimal TotalSaleAmount { get; }
    public bool IsCanceled { get; }
    public decimal TotalSaleDiscount { get; }
    public string Branch { get; }
}
