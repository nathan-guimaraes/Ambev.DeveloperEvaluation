using Ambev.DeveloperEvaluation.Domain.Common;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Products.ListCategory;

public sealed record ListCategoryCommand : PagedOrderedBase, IRequest<string[]>
{
    public ListCategoryCommand()
    {

    }

    public ListCategoryCommand(PagedOrderedBase? request)
    {
        this._page = request?._page;
        this._size = request?._size;
        this._order = request?._order;
    }
}

