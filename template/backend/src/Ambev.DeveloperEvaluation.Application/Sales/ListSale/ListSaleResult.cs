using Ambev.DeveloperEvaluation.Application.Sales.GetSale;
using Ambev.DeveloperEvaluation.Domain.Common;

namespace Ambev.DeveloperEvaluation.Application.Sales.ListSale;

public record ListSaleResult(PaginatedResult<GetSaleResult> Sales)
{
    public ListSaleResult() : this(new PaginatedResult<GetSaleResult>())
    {
    }
}