using Ambev.DeveloperEvaluation.Domain.ValueObjects;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Domain.Validation;

public static class SaleItemValidatorExtensions
{
    public static IRuleBuilderOptions<T, IEnumerable<CartItemSale>> MaxSaleItemQuantity<T>(
        this IRuleBuilder<T, IEnumerable<CartItemSale>> ruleBuilder,
        int maximumQuantity = 20)
    {
        return ruleBuilder
            .Must(items => items.GroupBy(i => i.ProductId).All(g => g.Sum(i => i.Quantity) <= maximumQuantity))
            .WithMessage($"The sum of items by product id must be less than or equal to {maximumQuantity}.");
    }
}