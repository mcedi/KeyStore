﻿using FluentValidation;

namespace KeyStore.Application.Auth.Commands.BeginLoginCommand;

public class BeginLoginModelValidator : AbstractValidator<BeginLoginCommand>
{
    public BeginLoginModelValidator()
    {
        RuleFor(x => x.EmailAddress)
            .EmailAddress()
            .NotEmpty();
    }
}
