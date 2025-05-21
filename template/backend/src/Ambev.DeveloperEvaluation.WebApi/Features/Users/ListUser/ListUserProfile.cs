using Ambev.DeveloperEvaluation.Application.Users.GetUser;
using Ambev.DeveloperEvaluation.Application.Users.ListUsers;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Users.ListUsers;

public class ListUserProfile : Profile
{

    public ListUserProfile()
    {
        CreateMap<ListUserRequest, ListUserCommand>();
        CreateMap<ListUserResult, ListUserResponse>();
        CreateMap<GetUserResult, ListUserResponse>();
    }
}
