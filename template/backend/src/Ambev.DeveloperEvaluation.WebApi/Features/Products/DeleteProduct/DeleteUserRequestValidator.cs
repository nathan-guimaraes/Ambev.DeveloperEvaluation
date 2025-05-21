using Ambev.DeveloperEvaluation.WebApi.Features.Products.DeleteProduct;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Users.DeleteProduct;

/// <summary>
/// Validator for DeleteProductRequest
/// </summary>
public class DeleteProductRequestValidator : AbstractValidator<DeleteProductRequest>
{
    /// <summary>
    /// Initializes validation rules for DeleteProductRequest
    /// </summary>
    public DeleteProductRequestValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("User ID is required");
    }
}
