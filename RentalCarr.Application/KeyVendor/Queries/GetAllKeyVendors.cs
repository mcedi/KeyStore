using AutoMapper;
using KeyStore.Application.Common.Dto.Vendor;
using MediatR;
using MongoDB.Entities;

namespace KeyStore.Application.Vendor.Queries;

public record GetAllKeyVendors() : IRequest<KeyVendorListDto>;

public class GetAllKeyVendorsQueryHandler : IRequestHandler<GetAllKeyVendors, KeyVendorListDto>
{
    private readonly IMapper _mapper;

    public GetAllKeyVendorsQueryHandler(IMapper mapper)
    {
        _mapper = mapper;
    }

    public async Task<KeyVendorListDto> Handle(GetAllKeyVendors request, CancellationToken cancellationToken)
    {
        return _mapper.Map<KeyVendorListDto>(await DB.Find<Domain.Entities.KeyVendor>()
            .ExecuteAsync(cancellation: cancellationToken));
    }
}
