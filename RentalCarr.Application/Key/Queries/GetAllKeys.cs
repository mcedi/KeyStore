using AutoMapper;
using KeyStore.Application.Common.Dto.Key;

using MediatR;
using MongoDB.Entities;

namespace KeyStore.Application.Licence.Queries;

public record GetAllKeys : IRequest<KeyListDto>;

public class GetAllKeysQueryHandler : IRequestHandler<GetAllKeys, KeyListDto>
{
    private readonly IMapper _mapper;

    public GetAllKeysQueryHandler(IMapper mapper)
    {
        _mapper = mapper;
    }

    public async Task<KeyListDto> Handle(GetAllKeys request, CancellationToken cancellationToken)
    {
        return _mapper.Map<KeyListDto>(await DB.Find<Domain.Entities.Key>()
            .ExecuteAsync(cancellation: cancellationToken));
    }
}
