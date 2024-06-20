using AutoMapper;

using KeyStore.Application.Common.Exceptions;
using KeyStore.Application.Common.Interfaces;
using MediatR;
using KeyStore.Application.Common.Dto.User;
using KeyStore.Application.Common.Interfaces;

namespace KeyStore.Application.Users.Queries;

public record GetOneUser(string UserId) : IRequest<UserInformationDto>;

public class GetOneUserQueryHandler : IRequestHandler<GetOneUser, UserInformationDto>
{
    private readonly IUserService _userService;
    private readonly IMapper _mapper;

    public GetOneUserQueryHandler(IUserService userService, IMapper mapper)
    {
        _userService = userService;
        _mapper = mapper;
    }

    public async Task<UserInformationDto> Handle(GetOneUser request, CancellationToken cancellationToken)
    {
        var user = await _userService.GetUserAsync(request.UserId);
        if (user == null)
            throw new NotFoundException("User not found");

        return await Task.FromResult(_mapper.Map<UserInformationDto>(user));
    }
}