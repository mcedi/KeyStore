using KeyStore.Application.Common.Dto.Key;
using KeyStore.Application.Common.Interfaces;
using MediatR;
using MongoDB.Entities;


namespace KeyStore.Application.Key.Commands;

public record CreateKey(CreateKeyDto Key) : IRequest<string>;

public record CreateKeyCommandHandler : IRequestHandler<CreateKey, string>
{
    private readonly IUserService _userService;

    public CreateKeyCommandHandler(IUserService userService)
    {
        _userService = userService;
    }

    public async Task<string> Handle(CreateKey request, CancellationToken cancellationToken)
    {
        var keyVendor = await DB.Find<KeyStore.Domain.Entities.KeyVendor>()
            .OneAsync(request.Key.KeyVendorId, cancellationToken);

        if (keyVendor == null)
        {
            throw new Exception("Key Vendor not found");
        }

        var keyCategory = await DB.Find<KeyStore.Domain.Entities.KeyCategory>()
            .OneAsync(request.Key.KeyCategoryId, cancellationToken);

        if (keyCategory == null)
        {
            throw new Exception("Key Category not found");
        }

        var keyType = await DB.Find<KeyStore.Domain.Entities.KeyType>()
            .OneAsync(request.Key.KeyTypeId, cancellationToken);

        if (keyType == null)
        {
            throw new Exception("Key type not found");
        }

        var user = await _userService.GetUserAsync(request.Key.OwnerId);

        var data = new KeyStore.Domain.Entities.Key()
        {
            Name = request.Key.Name,
            Img = request.Key.Img,
            Description = request.Key.Description,
            KeyVendor = new One<KeyStore.Domain.Entities.KeyVendor>(keyVendor),
            KeyCategory = new One<KeyStore.Domain.Entities.KeyCategory>(keyCategory),
            KeyType = new One<KeyStore.Domain.Entities.KeyType>(keyType),
            IsSold = request.Key.IsSold,
            Price = request.Key.Price,
            Active = true,
            StartDate = request.Key.StartDate,
            EndDate = request.Key.EndDate
        };

        if (user != null)
        {
            data.Owner = user;
        }

        await data.SaveAsync(cancellation: cancellationToken);

        return "Key successfully created!";

    }
}

