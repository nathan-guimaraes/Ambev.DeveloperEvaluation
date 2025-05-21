using Ambev.DeveloperEvaluation.Domain.Common;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Products.ListProduct;

public sealed record ListProductCommand : PagedOrderedBase, IRequest<ListProductResult>
{
    public ListProductCommand()
    {

    }

    public ListProductCommand(PagedOrderedBase? request)
    {
        this._page = request?._page;
        this._size = request?._size;
        this._order = request?._order;
    }
}

