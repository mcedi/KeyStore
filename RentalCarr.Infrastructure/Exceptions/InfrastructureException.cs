﻿using KeyStore.Domain.Exceptions;

namespace KeyStore.Infrastructure.Exceptions;

public class InfrastructureException : BaseException
{
    public InfrastructureException(string message, object? additionalData = null) : base(message,
        additionalData)
    {
    }

    public InfrastructureException(string message, Exception innerException, object? additionalData = null) : base(message,
        innerException,
        additionalData)
    {
    }
}
