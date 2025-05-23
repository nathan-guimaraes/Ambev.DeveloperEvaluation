using Ambev.DeveloperEvaluation.Application.Products.GetProduct;
using Ambev.DeveloperEvaluation.Domain.Common;

namespace Ambev.DeveloperEvaluation.Application.Products.ListCategory;

public record ListCategoryResult(PaginatedResult<string[]> Categories)
{
    public ListCategoryResult() : this(new PaginatedResult<string[]>())
    {
    }
}