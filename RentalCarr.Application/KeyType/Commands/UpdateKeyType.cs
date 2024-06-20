using AutoMapper;
using KeyStore.Application.Common.Dto.KeyType;
using KeyStore.Application.Common.Exceptions;
using MediatR;
using MongoDB.Entities;

using NotFoundException = KeyStore.Application.Common.Exceptions.NotFoundException;

namespace KeyStore.Application.KeyType.Commands;

public record UpdateKeyType(UpdateKeyTypeDto KeyType) : IRequest<string>;

public class UpdateKeyTypeCommandHandler : IRequestHandler<UpdateKeyType, string>
{
    private readonly IMapper _mapper;

    public UpdateKeyTypeCommandHandler(IMapper mapper)
    {
        _mapper = mapper;
    }

    public async Task<string> Handle(UpdateKeyType request, CancellationToken cancellationToken)
    {
        var licenceType = await DB.Find<Domain.Entities.KeyType>()
            .OneAsync(request.KeyType.KeyTypeId, cancellation: cancellationToken);

        if (licenceType == null)
        {
            throw new NotFoundException("Key Type not found");
        }

        _mapper.Map(request.KeyType, licenceType);
        await licenceType.SaveAsync(cancellation: cancellationToken);

        return "Key successfully updated!";
    }
}