using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using KeyStore.Application.Car.Commands;
using KeyStore.Application.Car.Queries;


namespace KeyStore.Api.Controllers;

[Route("car")]
[Authorize]
public class CarController : ApiControllerBase
{
    [HttpGet("GetOneCar")]
    public async Task<ActionResult> GetCar([FromQuery] GetCarQuery query) => Ok(await Mediator.Send(query));

    [HttpPost("CreateCar")]
    public async Task<ActionResult> CreateCar(CreateCarCommand command)
    {
        await Mediator.Send(command);
        return Ok();
    }
}
