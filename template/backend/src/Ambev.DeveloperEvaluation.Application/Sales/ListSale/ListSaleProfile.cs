using Ambev.DeveloperEvaluation.Application.Sales.GetSale;
using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Entities;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.Sales.ListSale;

public class ListSaleProfile : Profile
{

    public ListSaleProfile()
    {
        CreateMap<ListSaleResult, PaginatedResult<Sale>>()
            .ForMember(x => x.Data, o => o.MapFrom(s => s.Sales.Data))
            .ForMember(x => x.TotalItems, o => o.MapFrom(s => s.Sales.TotalItems))
            .ForMember(x => x.CurrentPage, o => o.MapFrom(s => s.Sales.CurrentPage))
            .ForMember(x => x.PageSize, o => o.MapFrom(s => s.Sales.PageSize))
            .ForMember(x => x.TotalPages, o => o.MapFrom(s => s.Sales.TotalPages))
            .ReverseMap();
    }
}
