using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Products.ListProduct;

public class ListProductValidator : AbstractValidator<ListProductCommand>
{
    public ListProductValidator()
    {
        //RuleFor(x => x.Id)
        //    .NotEmpty()
        //    .WithMessage("Product ID is required");
    }
}
