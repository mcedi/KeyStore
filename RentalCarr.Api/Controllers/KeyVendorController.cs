using KeyStore.Application.Common.Dto.Vendor;
using KeyStore.Application.KeyVendor.Commands;
using KeyStore.Application.KeyVendor.Queries;
using KeyStore.Application.Vendor.Commands;
using KeyStore.Application.Vendor.Queries;
using Microsoft.AspNetCore.Mvc;

namespace KeyStore.Api.Controllers;

[Route("vendor")]
public class KeyVendorController : ApiControllerBase
{

    [HttpPost("CreateKeyVendor")]
    public async Task<ActionResult<string>> CreateKeyVendor(CreateKeyVendor command) =>
        Ok(await Mediator.Send(command));

    [HttpPut("UpdateKeyVendor")]
    public async Task<ActionResult<string>> UpdateKeyVendor(UpdateKeyVendor command) =>
        Ok(await Mediator.Send(command));

    [HttpDelete("DeleteKeyVendor")]
    public async Task<ActionResult<string>> DeleteKeyVendor(DeleteKeyVendor command) =>
        Ok(await Mediator.Send(command));

    [HttpGet("GetOneKeyVendor")]
    public async Task<ActionResult<KeyVendorInformationDto>> GetKeyVendor([FromQuery] GetOneKeyVendor query) =>
        Ok(await Mediator.Send(query));


    [HttpGet("GetAllKeyVendors")]
    public async Task<ActionResult<KeyVendorListDto>> GetAllKeyVendors([FromQuery] GetAllKeyVendors query) =>
        Ok(await Mediator.Send(query));
}