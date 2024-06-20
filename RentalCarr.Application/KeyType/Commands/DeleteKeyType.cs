using MediatR;
using MongoDB.Entities;

namespace KeyStore.Application.KeyType.Commands;

public record DeleteKeyType(string KeyTypeId) : IRequest<string>;

public class DeleteLicenceTypeCommandHandler : IRequestHandler<DeleteKeyType, string>
{
    public async Task<string> Handle(DeleteKeyType request, CancellationToken cancellationToken)
    {
        await DB.DeleteAsync<Domain.Entities.KeyType>(key => key.ID != null
            && key.Equals(request.KeyTypeId),
            cancellation: cancellationToken);

        return "Key Type deleted successfully";
    }
}