using AutoMapper;
using KeyStore.Application.Common.Dto.KeyType;
using MediatR;
using MongoDB.Entities;


namespace KeyStore.Application.KeyType.Commands;

public record CreateKeyType(CreateKeyTypeDto KeyType) : IRequest<string>;

public class CreateKeyTypeCommandHandler : IRequestHandler<CreateKeyType, string>
{
    private readonly IMapper _mapper;

    public CreateKeyTypeCommandHandler(IMapper mapper)
    {
        _mapper = mapper;
    }

    public async Task<string> Handle(CreateKeyType request, CancellationToken cancellationToken)
    {
        var keyType = _mapper.Map<Domain.Entities.KeyType>(request.KeyType);
        await keyType.SaveAsync(cancellation: cancellationToken);

        return "Key Type successfully created";
    }
}
