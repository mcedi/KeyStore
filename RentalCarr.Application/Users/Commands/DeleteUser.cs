using AutoMapper;
using KeyStore.Application.Common.Exceptions;
using KeyStore.Application.Common.Interfaces;
using MediatR;
using KeyStore.Application.Common.Interfaces;

namespace KeyStore.Application.Users.Commands;

public record DeleteUser(string UserId) : IRequest<string>;

public class DeleteUserCommandHandler : IRequestHandler<DeleteUser, string>
{
    private readonly IUserService _userService;
    private readonly IMapper _mapper;

    public DeleteUserCommandHandler(IUserService userService, IMapper mapper)
    {
        _userService = userService;
        _mapper = mapper;
    }

    public Task<string> Handle(DeleteUser request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

   
}
