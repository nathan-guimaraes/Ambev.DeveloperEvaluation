using Ambev.DeveloperEvaluation.Domain.Common;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.ListProduct;

/// <summary>
/// Request model for getting a list of users
/// </summary>
public record ListProductRequest : PagedOrderedBase;