using MediatR;
using MongoDB.Entities;

namespace KeyStore.Application.Order.Commands;

public record DeleteOrder(string OrderId) : IRequest<string>;

public class DeleteOrderCommandHandler : IRequestHandler<DeleteOrder, string>
{
    public async Task<string> Handle(DeleteOrder request, CancellationToken cancellationToken)
    {
        await DB.DeleteAsync<Domain.Entities.Order>(o => o.ID != null && o.ID.Equals(request.OrderId),
            cancellation: cancellationToken);
        return "Order successfully deleted!";
    }
}
