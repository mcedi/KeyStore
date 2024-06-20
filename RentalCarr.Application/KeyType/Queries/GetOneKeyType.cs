using AutoMapper;
using KeyStore.Application.Common.Dto.KeyType;
using KeyStore.Application.Common.Exceptions;
using MediatR;
using MongoDB.Entities;


namespace KeyStore.Application.KeyType.Queries;

public record GetOneKeyType(string KeyTypeId) : IRequest<KeyTypeInformationDto>;

public class GetOneKeyTypeQueryHandler : IRequestHandler<GetOneKeyType, KeyTypeInformationDto>
{
    private readonly IMapper _mapper;

    public GetOneKeyTypeQueryHandler(IMapper mapper)
    {
        _mapper = mapper;
    }

    public async Task<KeyTypeInformationDto> Handle(GetOneKeyType request, CancellationToken cancellationToken)
    {
        var keyType = await DB.Find<Domain.Entities.KeyType>()
            .OneAsync(request.KeyTypeId, cancellation: cancellationToken);

        if (keyType == null)
        {
            throw new NotFoundException("Key Type not found");
        }

        return _mapper.Map<KeyTypeInformationDto>(keyType);
    }
}
