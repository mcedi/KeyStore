using KeyStore.Application.Category.Commands;
using KeyStore.Application.Category.Queries;
using KeyStore.Application.Common.Dto.Category;

using Microsoft.AspNetCore.Mvc;


namespace KeyStore.Api.Controllers;

[Route("keyCategory")]
public class KeyCategoryController : ApiControllerBase
{
    [HttpPost("CreateKeyCategory")]
    public async Task<ActionResult<string>> CreateKeyCategory(CreateKeyCategory command) =>
        Ok(await Mediator.Send(command));

    [HttpPut("UpdateKeyCategory")]
    public async Task<ActionResult<string>> UpdateKeyCategory(UpdateKeyCategory command) =>
        Ok(await Mediator.Send(command));

    [HttpGet("GetOneKeyCategory")]
    public async Task<ActionResult<KeyCategoryInformationDto>> GetOneKeyCategory([FromQuery] GetOneKeyCategory query) =>
        Ok(await Mediator.Send(query));

    [HttpGet("GetAllKeyCategories")]
    public async Task<ActionResult<KeyCategoryInformationDto>> GetAllKeyCategories([FromQuery] GetAllKeyCategories query) =>
        Ok(await Mediator.Send(query));

}