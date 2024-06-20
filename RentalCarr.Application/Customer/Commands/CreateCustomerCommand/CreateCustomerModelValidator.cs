using FluentValidation;

namespace KeyStore.Application.Customer.Commands.CreateCustomerCommand;

public class CreateCustomerModelValidator : AbstractValidator<CreateCustomerCommand>
{
    public CreateCustomerModelValidator()
    {
        RuleFor(x => x.EmailAddress)
            .EmailAddress()
            .NotEmpty();
    }
}
