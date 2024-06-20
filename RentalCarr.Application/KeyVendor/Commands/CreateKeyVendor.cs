using AutoMapper;
using KeyStore.Application.Common.Dto.User;
using KeyStore.Application.Common.Dto.Vendor;
using MediatR;
using MongoDB.Entities;

namespace KeyStore.Application.Vendor.Commands;

public record CreateKeyVendor(CreateKeyVendorDto KeyVendor) : IRequest<string>;

public class CreateKeyVendorCommandHandler : IRequestHandler<CreateKeyVendor, string>
{
    private readonly IMapper _mapper;

    public CreateKeyVendorCommandHandler(IMapper mapper)
    {
        _mapper = mapper;
    }

    public async Task<string> Handle(CreateKeyVendor request, CancellationToken cancellationToken)
    {
        var KeyVendor = _mapper.Map<Domain.Entities.KeyVendor>(request.KeyVendor);
        await KeyVendor.SaveAsync(cancellation: cancellationToken);

        return "Key Vendor successfully created!";
    }
}
