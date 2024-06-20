using AutoMapper;

using KeyStore.Application.Common.Exceptions;
using MediatR;
using MongoDB.Entities;
using KeyStore.Application.Common.Dto.Key;

namespace KeyStore.Application.Key.Queries;

public record GetOneKey(string KeyId) : IRequest<KeyInformationDto>;

public class GetOneKeyQueryHandler : IRequestHandler<GetOneKey, KeyInformationDto>
{
    private readonly IMapper _mapper;

    public GetOneKeyQueryHandler(IMapper mapper)
    {
        _mapper = mapper;
    }

    public async Task<KeyInformationDto> Handle(GetOneKey request, CancellationToken cancellationToken)
    {
        var key = await DB.Find<KeyStore.Domain.Entities.Key>()
            .OneAsync(request.KeyId, cancellation: cancellationToken);
        if (key == null)
            throw new NotFoundException("Key not found");
        return await _mapper.Map<Task<KeyInformationDto>>(key);
    }
}
