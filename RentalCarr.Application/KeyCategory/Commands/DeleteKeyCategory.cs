using MediatR;
using MongoDB.Entities;

namespace KeyStore.Application.Category.Commands;

public record DeleteKeyCategory(string KeyCategoryId) : IRequest<string>;

public class DeleteKeyCategoryCommandHandler : IRequestHandler<DeleteKeyCategory, string>
{
    public async Task<string> Handle(DeleteKeyCategory request, CancellationToken cancellationToken)
    {
        await DB.DeleteAsync<Domain.Entities.KeyCategory>(
            cat => cat.ID != null && cat.ID.Equals(request.KeyCategoryId), cancellation: cancellationToken);

        return "Key Category deleted successfully!";
    }
};