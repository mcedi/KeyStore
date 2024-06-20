using AutoMapper;

using KeyStore.Application.Common.Exceptions;
using MediatR;
using MongoDB.Entities;

using KeyStore.Application.Common.Dto.Key;

namespace KeyStore.Application.Key.Commands;

public record UpdateKey(UpdateKeyDto Key) : IRequest<string>;

public class UpdateKeyCommandHandler : IRequestHandler<UpdateKey, string>
{
    private readonly IMapper _mapper;

    public UpdateKeyCommandHandler(IMapper mapper)
    {
        _mapper = mapper;
    }
    public async Task<string> Handle(UpdateKey request, CancellationToken cancellationToken)
    {
        var key = await DB.Find<KeyStore.Domain.Entities.Key>()
            .OneAsync(request.Key.KeyId, cancellation: cancellationToken);

        if (key == null)
        {
            throw new NotFoundException("Key not found");
        }

        _mapper.Map(request.Key, key);
        await key.SaveAsync(cancellation: cancellationToken);

        return "Key successfully updated!";
    }
}
