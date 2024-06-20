using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using KeyStore.Application.Administrator.Commands.CreateAdministratorCommand;
using KeyStore.Application.Customer.Commands.CreateCustomerCommand;

using KeyStore.Application.Auth.Commands.BeginLoginCommand;
using KeyStore.Application.Auth.Commands.CompleteLoginCommand;





namespace KeyStore.Api.Controllers;

public class AuthController : ApiControllerBase
{

    [AllowAnonymous]
    [HttpPost("BeginLogin")]
    public async Task<ActionResult> BeginLogin(BeginLoginCommand command) => Ok(await Mediator.Send(command));

    [AllowAnonymous]
    [HttpGet("{validationToken}/CompleteLogin")]
    public async Task<ActionResult> CompleteLogin([FromRoute] string validationToken) => Ok(await Mediator.Send(new CompleteLoginCommand(validationToken)));

    [AllowAnonymous]
    [HttpPost("RegisterCustomer")]
    public async Task<ActionResult> RegisterCustomer(CreateCustomerCommand command)
    {
        await Mediator.Send(command);
        return Ok();
    }

    [AllowAnonymous]
    [HttpPost("RegisterAdmin")]
    public async Task<ActionResult> RegisterAdministrator(CreateAdministratorCommand command)
    {
        await Mediator.Send(command);
        return Ok();
    }
    
}
