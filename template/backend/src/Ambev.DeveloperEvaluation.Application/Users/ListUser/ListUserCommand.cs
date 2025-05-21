using Ambev.DeveloperEvaluation.Domain.Common;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Users.ListUsers;

public sealed record ListUserCommand : PagedOrderedBase, IRequest<ListUserResult>
{
    public ListUserCommand()
    {

    }

    public ListUserCommand(PagedOrderedBase? request)
    {
        this._page = request?._page;
        this._size = request?._size;
        this._order = request?._order;
    }
}

