using Ambev.DeveloperEvaluation.Domain.ValueObjects;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSale;

/// <summary>
/// Represents a request to create a new user in the system.
/// </summary>
public class CreateSaleRequest
{
    public Guid UserId { get; set; }
    public List<CartItemSale> Items { get; set; }
    public string Branch { get; set; } = string.Empty;
}

