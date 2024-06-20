using KeyStore.Application.Common.Dto.Key;
using KeyStore.Application.Key.Commands;
using Microsoft.AspNetCore.Mvc;
using KeyStore.Application.Licence.Queries;
using KeyStore.Application.Key.Commands;
using KeyStore.Application.Key.Queries;

namespace KeyStore.Api.Controllers;

[Route("key")]
public class KeyController : ApiControllerBase
{

    [HttpPost("CreateKey")]
    public async Task<ActionResult<string>> CreateKey(CreateKey command) =>
        Ok(await Mediator.Send(command));

    [HttpPost("UpdateKey")]
    public async Task<ActionResult<string>> UpdateKey(UpdateKey command) =>
        Ok(await Mediator.Send(command));

    [HttpDelete("DeleteKey")]
    public async Task<ActionResult<string>> DeleteKey(DeleteKey command) =>
        Ok(await Mediator.Send(command));

    [HttpGet("GetOneLicence")]
    public async Task<ActionResult<KeyInformationDto>> GetOneKey([FromQuery] GetOneKey query) =>
        Ok(await Mediator.Send(query));

    [HttpGet("GetAllLicences")]
    public async Task<ActionResult<KeyInformationDto>> GetAllKeys([FromQuery] GetAllKeys query) =>
        Ok(await Mediator.Send(query));

}