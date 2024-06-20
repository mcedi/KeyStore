using FluentValidation;
using KeyStore.Application.Common.Dto.Order;

namespace KeyStore.Application.Common.Validators.Order;

public class UpdateOrderDtoValidator : AbstractValidator<UpdateOrderDto>
{
    public UpdateOrderDtoValidator()
    {
        RuleFor(o => o.TotalPrice)
            .NotNull();
        RuleFor(o => o.Status)
            .NotEmpty();
    }
}