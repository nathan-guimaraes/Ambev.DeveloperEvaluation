using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Entities;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.Products.ListProduct;

public class ListProductProfile : Profile
{

    public ListProductProfile()
    {
        CreateMap<ListProductResult, PaginatedResult<Product>>()
            .ForMember(x => x.Data, o => o.MapFrom(s => s.Products.Data))
            .ForMember(x => x.TotalItems, o => o.MapFrom(s => s.Products.TotalItems))
            .ForMember(x => x.CurrentPage, o => o.MapFrom(s => s.Products.CurrentPage))
            .ForMember(x => x.PageSize, o => o.MapFrom(s => s.Products.PageSize))
            .ForMember(x => x.TotalPages, o => o.MapFrom(s => s.Products.TotalPages))
            .ReverseMap();
    }
}
