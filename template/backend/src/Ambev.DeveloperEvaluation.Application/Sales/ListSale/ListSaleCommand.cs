using Ambev.DeveloperEvaluation.Domain.Common;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.ListSale;

public sealed record ListSaleCommand : PagedOrderedBase, IRequest<ListSaleResult>
{
    public ListSaleCommand()
    {

    }

    public ListSaleCommand(PagedOrderedBase? request)
    {
        _page = request?._page;
        _size = request?._size;
        _order = request?._order;
    }
}