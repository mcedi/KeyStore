using MediatR;
using MongoDB.Entities;

namespace KeyStore.Application.Vendor.Commands;

public record DeleteKeyVendor(string KeyVendorId) : IRequest<string>;

public class DeleteKeyVendorCommandHandler : IRequestHandler<DeleteKeyVendor, string>
{
    public async Task<string> Handle(DeleteKeyVendor request, CancellationToken cancellationToken)
    {
        await DB.DeleteAsync<Domain.Entities.KeyVendor>(v => v.ID != null && v.ID.Equals(request.KeyVendorId),
            cancellation: cancellationToken);
        return "Key Vendor successfully deleted!";
    }
}
