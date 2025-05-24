using Ambev.DeveloperEvaluation.Domain.ValueObjects;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sale.ListSale;

public class ListSaleResponse
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public DateTime SaleDate { get; set; }
    public List<SaleItem> SaleItems { get; set; } = [];
    public decimal TotalSaleAmount { get; set; } = 0;
    public bool IsCanceled { get; set; } = false;
    public decimal TotalSaleDiscount { get; set; } = 0;
    public string Branch { get; set; } = string.Empty;
}
