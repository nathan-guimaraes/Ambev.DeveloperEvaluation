using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Users.ListUsers;


public class ListUserHandler : IRequestHandler<ListUserCommand, ListUserResult>
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public ListUserHandler(
        IUserRepository userRepository,
        IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<ListUserResult> Handle(ListUserCommand request, CancellationToken cancellationToken)
    {
        //var validator = new GetUserValidator();
        //var validationResult = await validator.ValidateAsync(request, cancellationToken);

        //if (!validationResult.IsValid)
        //    throw new ValidationException(validationResult.Errors);

        var users = await _userRepository.ListUsersAsync(request, cancellationToken);

        return _mapper.Map<ListUserResult>(users);
    }
}
