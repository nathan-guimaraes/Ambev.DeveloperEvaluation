using AutoMapper;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Application.Products.CreateProduct;

namespace Ambev.DeveloperEvaluation.Application.Users.CreateProduct;

/// <summary>
/// Profile for mapping between User entity and CreateProductResponse
/// </summary>
public class CreateProductProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for CreateProduct operation
    /// </summary>
    public CreateProductProfile()
    {
        CreateMap<CreateProductCommand, User>();
        CreateMap<User, CreateProductResult>();
    }
}
