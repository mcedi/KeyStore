using AutoMapper;
using KeyStore.Application.Common.Dto.User;
using KeyStore.Application.Common.Interfaces;
using MediatR;
using KeyStore.Application.Common.Interfaces;

namespace KeyStore.Application.Users.Queries;

public record GetAllUsers() : IRequest<UserListDto>;

public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsers, UserListDto>
{
    private readonly IMapper _mapper;
    private readonly IUserService _userService;

    public GetAllUsersQueryHandler(IMapper mapper, IUserService userService)
    {
        _mapper = mapper;
        _userService = userService;
    }

    public Task<UserListDto> Handle(GetAllUsers request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

   
}