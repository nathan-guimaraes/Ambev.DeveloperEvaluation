using Ambev.DeveloperEvaluation.Application.Users.GetUser;
using Ambev.DeveloperEvaluation.Domain.Common;

namespace Ambev.DeveloperEvaluation.Application.Users.ListUsers;

public record ListUserResult(PaginatedResult<GetUserResult> Users)
{
    public ListUserResult() : this(new PaginatedResult<GetUserResult>())
    {
    }
}