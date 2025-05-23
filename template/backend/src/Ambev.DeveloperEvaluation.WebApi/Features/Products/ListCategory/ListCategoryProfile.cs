using Ambev.DeveloperEvaluation.Application.Products.GetProduct;
using Ambev.DeveloperEvaluation.Application.Products.ListCategory;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.ListCategory;

public class ListCategoryProfile : Profile
{

    public ListCategoryProfile()
    {
        //CreateMap<ListCategoryRequest, ListCategoryCommand>();
        CreateMap<ListCategoryResult, ListCategoryResponse>();
        CreateMap<GetProductResult, ListCategoryResponse>();
    }
}
