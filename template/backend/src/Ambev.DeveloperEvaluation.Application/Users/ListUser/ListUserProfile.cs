using AutoMapper;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Common;

namespace Ambev.DeveloperEvaluation.Application.Users.ListUsers;

public class ListUserProfile : Profile
{

    public ListUserProfile()
    {
        CreateMap<ListUserResult, PaginatedResult<User>>()
            .ForMember(x => x.Data, o => o.MapFrom(s => s.Users.Data))
            .ForMember(x => x.TotalItems, o => o.MapFrom(s => s.Users.TotalItems))
            .ForMember(x => x.CurrentPage, o => o.MapFrom(s => s.Users.CurrentPage))
            .ForMember(x => x.PageSize, o => o.MapFrom(s => s.Users.PageSize))
            .ForMember(x => x.TotalPages, o => o.MapFrom(s => s.Users.TotalPages))
            .ReverseMap();
    }
}
