using Ardalis.GuardClauses;
using MongoDB.Entities;
using KeyStore.Domain.Common;
using KeyStore.Domain.Common.Locale;

namespace KeyStore.Domain.Entities;

[Collection("Cars")]
public class Car : AuditableEntity
{
    public Locales Locales { get; private set; }
    public int NumberOfDoors { get; private set; }

    private Car()
    {
    }

    public Car(Locales locales, int numberOfDoors)
    {
        Locales = Guard.Against.Null(locales,
            nameof(locales));
        NumberOfDoors = Guard.Against.NegativeOrZero(numberOfDoors,
            nameof(numberOfDoors));
    }
}
