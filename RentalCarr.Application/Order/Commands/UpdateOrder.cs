using AutoMapper;
using KeyStore.Application.Common.Dto.Order;
using KeyStore.Application.Common.Exceptions;
using MediatR;
using MongoDB.Entities;
using KeyStore.Application.Common.Dto.Order;

namespace KeyStore.Application.Order.Commands;

public record UpdateOrder(UpdateOrderDto Order) : IRequest<string>;

public class UpdateOrderCommandHandler : IRequestHandler<UpdateOrder, string>
{
    private readonly IMapper _mapper;

    public UpdateOrderCommandHandler(IMapper mapper)
    {
        _mapper = mapper;
    }

    public async Task<string> Handle(UpdateOrder request, CancellationToken cancellationToken)
    {
        var order = await DB.Find<Domain.Entities.Order>()
            .OneAsync(request.Order.OrderId, cancellation: cancellationToken);

        if (order == null)
            throw new NotFoundException("Order not found");

        _mapper.Map(request.Order, order);
        await order.SaveAsync(cancellation: cancellationToken);

        return "Order successfully updated!";
    }
}
