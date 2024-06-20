using KeyStore.Application.Common.Dto.Order;
using KeyStore.Application.Order.Commands;

using Microsoft.AspNetCore.Mvc;
using KeyStore.Application.Order.Queries;

namespace KeyStore.Api.Controllers;

[Route("order")]
public class OrderController : ApiControllerBase
{

    [HttpPost("CreateOrder")]
    public async Task<ActionResult<string>> CreateOrder(CreateOrder command) =>
        Ok(await Mediator.Send(command));

    [HttpPost("UpdateOrder")]
    public async Task<ActionResult<string>> UpdateOrder(UpdateOrder command) =>
        Ok(await Mediator.Send(command));

    [HttpDelete("DeleteOrder")]
    public async Task<ActionResult<string>> DeleteOrder(DeleteOrder command) =>
        Ok(await Mediator.Send(command));

    [HttpGet("GetOneOrder")]
    public async Task<ActionResult<OrderInformationDto>> GetOneOrder([FromQuery] GetOneOrder query) =>
        Ok(await Mediator.Send(query));

    [HttpGet("GetAllOrders")]
    public async Task<ActionResult<OrderInformationDto>> GetAllOrders([FromQuery] GetAllOrders query) =>
        Ok(await Mediator.Send(query));
}
