using KeyStore.Application.Common.Dto.Order;
using KeyStore.Application.Common.Exceptions;
using KeyStore.Application.Common.Interfaces;
using KeyStore.Domain.Entities;
using MediatR;
using MongoDB.Entities;
using KeyStore.Application.Common.Dto.Order;
using KeyStore.Application.Common.Interfaces;
using KeyStore.Domain.Entities;
using Microsoft.AspNetCore.DataProtection.KeyManagement;

namespace KeyStore.Application.Order.Commands;

public record CreateOrder(CreateOrderDto Order) : IRequest<string>;

public class CreateOrderCommandHandler : IRequestHandler<CreateOrder, string>
{
    private readonly IUserService _userService;

    public CreateOrderCommandHandler(IUserService userService)
    {
        _userService = userService;
    }

    public async Task<string> Handle(CreateOrder request, CancellationToken cancellationToken)
    {
        try
        {
            var orderCode = new Random().Next(1, 1000000000);

            var customer = await GetCustomerAsync(request.Order.CustomerId);

            if (customer == null)
                throw new NotFoundException("Customer not found!");

            var keys = await GetKeysAsync(request.Order.KeyIds, cancellationToken);

            var order = new Domain.Entities.Order
            {
                OrderCode = orderCode,
                Customer = customer,
                Keys = keys,
                TotalPrice = 0,
                Status = "Approved",
                Active = true
            };

            order.CalculateTotalPrice();

            

            if (order.TotalPrice > customer.Balance)
            {
                order.Status = "Rejected";
                order.Active = false;
            }
            else
            {
                customer.Balance -= order.TotalPrice;
                customer.Keys.AddRange(keys);
            }

            //await _userService.UpdateUserAsync(customer);

            await order.SaveAsync(cancellation: cancellationToken);

            return "Order was successfully created";
        }
        catch (Exception ex)
        {
            return $"Error creating order: {ex.Message}";
        }
    }

    private async Task<ApplicationUser?> GetCustomerAsync(string customerId)
    {
        return await _userService.GetUserAsync(customerId);
    }

    private async Task<List<Domain.Entities.Key>> GetKeysAsync(List<string> keyIds, CancellationToken cancellationToken)
    {
        var keys = new List<Domain.Entities.Key>();

        foreach (var item in keyIds)
        {
            var key = await DB.Find<Domain.Entities.Key>().OneAsync(item, cancellation: cancellationToken);

            if (key == null)
            {
                throw new Exception($"Key with ID {item} not found");
            }

            keys.Add(key);
        }

        return keys;
    }

   
}
