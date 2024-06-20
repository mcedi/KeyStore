using AutoMapper;
using KeyStore.Application.Common.Dto.User;
using KeyStore.Application.Common.Exceptions;
using KeyStore.Application.Common.Interfaces;
using MediatR;


namespace KeyStore.Application.Users.Commands;

public record UpdateUser(UpdateUserDto User) : IRequest<string>;

public class UpdateUserCommandHandler : IRequestHandler<UpdateUser, string>
{

    private readonly IUserService _userService;
    private readonly IMapper _mapper;

    public UpdateUserCommandHandler(IUserService userService, IMapper mapper)
    {
        _userService = userService;
        _mapper = mapper;
    }


    public async Task<string> Handle(UpdateUser request, CancellationToken cancellationToken)
    {
        var user = await _userService.GetUserAsync(request.User.UserId);
        if (user == null)
            throw new NotFoundException("User not found");

        _mapper.Map(request.User, user);
        

        return "User successfully updated!";
    }
}
