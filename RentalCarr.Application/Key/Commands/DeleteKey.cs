using MediatR;
using MongoDB.Entities;

namespace KeyStore.Application.Key.Commands;

public record DeleteKey(string KeyId) : IRequest<string>;

public class DeleteKeyCommandHandler : IRequestHandler<DeleteKey, string>
{
    public async Task<string> Handle(DeleteKey request, CancellationToken cancellationToken)
    {
        await DB.DeleteAsync<Domain.Entities.Key>(
            key => key.ID != null && key.ID.Equals(request.KeyId), cancellation: cancellationToken);

        return "Key successfully deleted!";
    }
}
