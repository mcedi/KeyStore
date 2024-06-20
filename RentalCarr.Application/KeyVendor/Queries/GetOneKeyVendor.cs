using AutoMapper;
using KeyStore.Application.Common.Dto.Vendor;
using KeyStore.Application.Common.Exceptions;
using MediatR;
using MongoDB.Entities;


namespace KeyStore.Application.KeyVendor.Queries;

public record GetOneKeyVendor(string KeyVendorId) : IRequest<KeyVendorInformationDto>;

public class GetOneKeyVendorQueryHandler : IRequestHandler<GetOneKeyVendor, KeyVendorInformationDto>
{
    private readonly IMapper _mapper;

    public GetOneKeyVendorQueryHandler(IMapper mapper)
    {
        _mapper = mapper;
    }

    public async Task<KeyVendorInformationDto> Handle(GetOneKeyVendor request, CancellationToken cancellationToken)
    {
        var keyVendor = await DB.Find<Domain.Entities.KeyVendor>()
            .OneAsync(request.KeyVendorId, cancellation: cancellationToken);

        if (keyVendor == null)
            throw new NotFoundException("Key Vendor not found");

        return _mapper.Map<KeyVendorInformationDto>(keyVendor);
    }
}