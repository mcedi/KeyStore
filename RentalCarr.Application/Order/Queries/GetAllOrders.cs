using AutoMapper;
using KeyStore.Application.Common.Dto.Order;
using MediatR;
using MongoDB.Entities;
using KeyStore.Application.Common.Dto.Order;

namespace KeyStore.Application.Order.Queries;

public record GetAllOrders() : IRequest<List<OrderInformationDto>>;

public class GetAllOrdersQueryHandler : IRequestHandler<GetAllOrders, List<OrderInformationDto>>
{
    private readonly IMapper _mapper;

    public GetAllOrdersQueryHandler(IMapper mapper)
    {
        _mapper = mapper;
    }

    public async Task<List<OrderInformationDto>> Handle(GetAllOrders request, CancellationToken cancellationToken)
    {
        var orders = await DB.Find<KeyStore.Domain.Entities.Order>()
            .ManyAsync(o => o.Active == true, cancellationToken);

        return _mapper.Map<List<OrderInformationDto>>(orders);
    }
};
