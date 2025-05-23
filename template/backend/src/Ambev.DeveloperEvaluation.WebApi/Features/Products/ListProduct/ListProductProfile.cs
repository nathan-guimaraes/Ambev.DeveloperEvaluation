using Ambev.DeveloperEvaluation.Application.Products.GetProduct;
using Ambev.DeveloperEvaluation.Application.Products.ListProduct;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.ListProduct;

public class ListProductProfile : Profile
{

    public ListProductProfile()
    {
        CreateMap<ListProductRequest, ListProductCommand>();
        CreateMap<ListProductResult, ListProductResponse>();
        CreateMap<GetProductResult, ListProductResponse>();
    }
}
