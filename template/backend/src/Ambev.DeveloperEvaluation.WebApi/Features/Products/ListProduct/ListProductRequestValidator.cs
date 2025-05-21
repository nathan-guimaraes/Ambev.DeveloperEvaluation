using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.ListProducts;

/// <summary>
/// Validator for GetProductRequest
/// </summary>
public class ListProductRequestValidator : AbstractValidator<ListProductRequest>
{
    /// <summary>
    /// Initializes validation rules for ListProductsRequest
    /// </summary>
    public ListProductRequestValidator()
    {
        //RuleFor(x => x.Id)
        //    .NotEmpty()
        //    .WithMessage("Product ID is required");
    }
}
