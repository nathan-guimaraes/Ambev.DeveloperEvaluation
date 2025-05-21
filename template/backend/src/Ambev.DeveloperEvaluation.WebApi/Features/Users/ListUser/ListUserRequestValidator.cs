using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Users.ListUsers;

/// <summary>
/// Validator for GetUserRequest
/// </summary>
public class ListUserRequestValidator : AbstractValidator<ListUserRequest>
{
    /// <summary>
    /// Initializes validation rules for ListUsersRequest
    /// </summary>
    public ListUserRequestValidator()
    {
        //RuleFor(x => x.Id)
        //    .NotEmpty()
        //    .WithMessage("User ID is required");
    }
}
