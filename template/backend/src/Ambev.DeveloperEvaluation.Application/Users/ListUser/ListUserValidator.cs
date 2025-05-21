using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Users.ListUsers;

public class ListUserValidator : AbstractValidator<ListUserCommand>
{
    public ListUserValidator()
    {
        //RuleFor(x => x.Id)
        //    .NotEmpty()
        //    .WithMessage("User ID is required");
    }
}
