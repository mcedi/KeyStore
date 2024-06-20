using MediatR;
using KeyStore.Application.Common.Constants;
using KeyStore.Application.Common.Interfaces;

namespace KeyStore.Application.Customer.Commands.CreateCustomerCommand;

public record CreateCustomerCommand(string EmailAddress) : IRequest;

public class CreateCustomerHandler : IRequestHandler<CreateCustomerCommand>
{
    private readonly IUserService _userService;

    public CreateCustomerHandler(IUserService userService)
    {
        _userService = userService;
    }

    public async Task Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
    {
        await _userService.CreateUserAsync(request.EmailAddress,
            new List<string> { KeyStoreAuthorization.Customer });
    }
}
