using AutoMapper;
using KeyStore.Application.Common.Dto.Order;
using KeyStore.Application.Common.Exceptions;
using MediatR;
using MongoDB.Entities;
using KeyStore.Application.Common.Dto.Order;

namespace KeyStore.Application.Order.Queries;

public record GetOneOrder(string OrderId) : IRequest<OrderInformationDto>;

public class GetOneOrderQueryHandler : IRequestHandler<GetOneOrder, OrderInformationDto>
{
    private readonly IMapper _mapper;

    public GetOneOrderQueryHandler(IMapper mapper)
    {
        _mapper = mapper;
    }

    public async Task<OrderInformationDto> Handle(GetOneOrder request, CancellationToken cancellationToken)
    {
        var order = await DB.Find<Domain.Entities.Order>().OneAsync(request.OrderId, cancellation: cancellationToken);

        if (order == null)
        {
            throw new NotFoundException("Order not found");
        }

        return _mapper.Map<OrderInformationDto>(order);
    }
}
