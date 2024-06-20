using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using KeyStore.Application.Administrator.Commands.CreateAdministratorCommand;
using KeyStore.Application.Customer.Commands.CreateCustomerCommand;
using KeyStore.Domain.Entities;
using KeyStore.Application.Common.Dto.User;

using KeyStore.Application.Users.Commands;
using KeyStore.Application.Users.Queries;
using KeyStore.Application.Common.Constants;


namespace KeyStore.Api.Controllers;

// [Authorize(Roles = $"{RentalCarAuthorization.Customer}, {RentalCarAuthorization.Administrator}")]
public class UserController : ApiControllerBase
{
   
    [HttpPost("CreateCustomer")]  // createUser
    
    public async Task<ActionResult> CreateCustomer(CreateCustomerCommand command)
    {
        await Mediator.Send(command);
        return Ok();
    }

    [HttpPost("CreateAdministrator")]
    [Authorize(Roles = KeyStoreAuthorization.Administrator)]
    public async Task<ActionResult> CreateAdministrator(CreateAdministratorCommand command)
    {
        await Mediator.Send(command);
        return Ok();
    }

    [HttpPut("UpdateUser")]
    public async Task<ActionResult<string>> UpdateUser(UpdateUser command)
        => Ok(await Mediator.Send(command));


    [HttpDelete("DeleteUser")]
    public async Task<ActionResult<string>> DeleteUser(DeleteUser command)
        => Ok(await Mediator.Send(command));

    [HttpGet("GetOneUser")]
    public async Task<ActionResult<UserInformationDto>> GetOneUser([FromQuery] GetOneUser query) =>
        Ok(await Mediator.Send(query));

    [HttpGet("GetAllUsers")]
    public async Task<ActionResult<List<ApplicationUser>>> GetAllUsers([FromQuery] GetAllUsers query) =>
        Ok(await Mediator.Send(query));

}
