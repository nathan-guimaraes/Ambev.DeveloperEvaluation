using Ambev.DeveloperEvaluation.Application.Products.ListProduct;
using Ambev.DeveloperEvaluation.Domain.Common;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Products.ListProductCategory;

public sealed record ListProductCategoryCommand : PagedOrderedBase, IRequest<ListProductResult>
{
    public string Category { get; set; } = string.Empty;

    public ListProductCategoryCommand()
    {

    }

    public ListProductCategoryCommand(string category, PagedOrderedBase? request)
    {
        this._page = request?._page;
        this._size = request?._size;
        this._order = request?._order;
        this.Category = category;
    }
}