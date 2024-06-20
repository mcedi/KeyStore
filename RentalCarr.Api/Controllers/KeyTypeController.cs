using KeyStore.Application.Common.Dto.KeyType;
using KeyStore.Application.KeyType.Commands;
using KeyStore.Application.KeyType.Queries;
using KeyStore.Application.KeyType.Commands;


using Microsoft.AspNetCore.Mvc;

namespace KeyStore.Api.Controllers;

[Route("keyType")]
public class KeyTypeController : ApiControllerBase
{

    [HttpPost("CreateKeyType")]
    public async Task<ActionResult<string>> CreateKeyType(CreateKeyType command) =>
        Ok(await Mediator.Send(command));

    [HttpPut("UpdateKeyType")]
    public async Task<ActionResult<string>> UpdateKeyType(UpdateKeyType command) =>
        Ok(await Mediator.Send(command));

    [HttpGet("GetOneKeyType")]
    public async Task<ActionResult<KeyTypeInformationDto>> GetOneKeyType([FromQuery] GetOneKeyType query) =>
        Ok(await Mediator.Send(query));

    [HttpGet("GetAllKeyTypes")]
    public async Task<ActionResult<KeyTypeInformationDto>> GetAllKeys([FromQuery] GetAllKeyTypes query) =>
        Ok(await Mediator.Send(query));

}