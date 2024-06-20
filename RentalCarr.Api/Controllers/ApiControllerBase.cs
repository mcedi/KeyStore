using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace KeyStore.Api.Controllers;

[ApiController]
public abstract class ApiControllerBase : ControllerBase
{
    private ISender? _mediator;

    protected ISender Mediator => _mediator ??= HttpContext.RequestServices.GetRequiredService<ISender>();
}
// MediatR is accessed by inheritance from ApiControllerBase (Api), allowing controller to send commands and queries
// to MediatR pipeline for processing