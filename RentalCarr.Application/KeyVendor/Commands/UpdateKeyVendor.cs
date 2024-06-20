using AutoMapper;
using KeyStore.Application.Common.Dto.Vendor;
using KeyStore.Application.Common.Exceptions;
using MediatR;
using MongoDB.Entities;


namespace KeyStore.Application.KeyVendor.Commands;

public record UpdateKeyVendor(UpdateKeyVendorDto KeyVendor) : IRequest<string>;

public class UpdateKeyVendorCommandHandler : IRequestHandler<UpdateKeyVendor, string>
{
    private readonly IMapper _mapper;

    public UpdateKeyVendorCommandHandler(IMapper mapper)
    {
        _mapper = mapper;
    }

    public async Task<string> Handle(UpdateKeyVendor request, CancellationToken cancellationToken)
    {
        var keyVendor = await DB.Find<Domain.Entities.KeyVendor>()
            .OneAsync(request.KeyVendor.KeyVendorId, cancellation: cancellationToken);

        if (keyVendor == null)
            throw new NotFoundException("Key Vendor not found");

        _mapper.Map(request.KeyVendor, keyVendor);
        await keyVendor.SaveAsync(cancellation: cancellationToken);

        return "Key Vendor successfully updated!";
    }
}