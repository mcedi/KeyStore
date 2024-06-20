using AutoMapper;
using KeyStore.Application.Common.Dto.Key;
using KeyStore.Application.Common.Dto.KeyType;

using MediatR;
using MongoDB.Entities;

namespace KeyStore.Application.KeyType.Queries;

public record GetAllKeyTypes() : IRequest<List<KeyTypeInformationDto>>;

public class GetAllKeyTypesQueryHandler : IRequestHandler<GetAllKeyTypes, List<KeyTypeInformationDto>>
{
    private readonly IMapper _mapper;

    public GetAllKeyTypesQueryHandler(IMapper mapper)
    {
        _mapper = mapper;
    }

    public async Task<List<KeyTypeInformationDto>> Handle(GetAllKeyTypes request, CancellationToken cancellationToken)
    {
        var keyTypes = await DB.Find<KeyStore.Domain.Entities.KeyType>()
            .ManyAsync(keyTypes => keyTypes.Active == true, cancellationToken);

        return _mapper.Map<List<KeyTypeInformationDto>>(keyTypes);
    }
};
