using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Contracts;
using Ambev.DeveloperEvaluation.Domain.ValueObjects;

namespace Ambev.DeveloperEvaluation.Domain.Entities;

public class Sale : BaseEntity, ISale
{
    public Guid UserId { get; set; }
    public long Number { get; set; }
    public DateTime SaleDate { get; set; }
    public List<SaleItem> Items { get; set; } = [];
    public decimal TotalSaleAmount { get; set; } = 0;
    public bool IsCanceled { get; set; } = false;
    public decimal TotalSaleDiscount { get; set; } = 0;
    public string Branch { get; set; } = string.Empty;

    string ISale.Id => Id.ToString();

    public void ApplyDiscount()
    {
        decimal totalAmount = 0;
        decimal totalDiscount = 0;

        foreach (var item in Items)
        {
            decimal discountRate = 0;

            if (item.Quantity >= 10)
                discountRate = 0.20m;
            else if (item.Quantity >= 4)
                discountRate = 0.10m;

            decimal itemTotal = item.Quantity * item.UnitPrice;
            decimal discountAmount = itemTotal * discountRate;
            decimal totalWithDiscount = itemTotal - discountAmount;

            item.TotalSaleItemAmount = itemTotal;
            item.TotalAmountWithDiscount = totalWithDiscount;

            totalAmount += totalWithDiscount;
            totalDiscount += discountAmount;
        }

        TotalSaleAmount = totalAmount;
        TotalSaleDiscount = totalDiscount;
    }
}

public interface ISale
{
    public string Id { get; }
    public long Number { get; }
    public Guid UserId { get; }
    public DateTime SaleDate { get; }
    public List<SaleItem> Items { get; }
    public decimal TotalSaleAmount { get; }
    public bool IsCanceled { get; }
    public decimal TotalSaleDiscount { get; }
    public string Branch { get; }
}