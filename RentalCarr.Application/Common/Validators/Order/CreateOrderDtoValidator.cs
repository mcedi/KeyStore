using FluentValidation;
using KeyStore.Application.Common.Dto.Order;


namespace KeyStore.Application.Common.Validators.Order;

public class CreateOrderDtoValidator : AbstractValidator<CreateOrderDto>
{
    public CreateOrderDtoValidator()
    {
        RuleFor(o => o.CustomerId)
            .NotEmpty()
            .MinimumLength(3);
        RuleFor(o => o.KeyIds)
            .Must(list => list.Count >= 1)
            .WithMessage("There must be at least one key");
    }

    private static bool ValidateStringList(IReadOnlyCollection<string>? stringList)
    {
        return stringList != null && stringList.All(str => !string.IsNullOrEmpty(str));
    }
}