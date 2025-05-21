using Ambev.DeveloperEvaluation.Application.Products.GetProduct;
using Ambev.DeveloperEvaluation.Domain.Common;

namespace Ambev.DeveloperEvaluation.Application.Products.ListProduct;

public record ListProductResult(PaginatedResult<GetProductResult> Products)
{
    public ListProductResult() : this(new PaginatedResult<GetProductResult>())
    {
    }
}