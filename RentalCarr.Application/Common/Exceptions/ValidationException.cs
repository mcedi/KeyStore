﻿using KeyStore.Domain.Exceptions;

namespace KeyStore.Application.Common.Exceptions;

public class ValidationException : BaseException
{
    public ValidationException(IDictionary<string, string[]> failures) : base("One or more validation failures have occurred.",
        failures)
    {
    }
}
