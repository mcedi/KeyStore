using KeyStore.Domain.Common;
using MongoDB.Entities;
using KeyStore.Domain.Common;
using KeyStore.Domain.Entities;
using System.Numerics;

namespace KeyStore.Domain.Entities;

[Collection("keys")]
public class Key : AuditableEntity
{
    public Key()
    {
    }

    [Field("name")]
    public string Name { get; set; }

    [Field("keyVendor")]
    public One<KeyVendor> KeyVendor { get; set; }

    [Field("keyCategory")]
    public One<KeyCategory> KeyCategory { get; set; }

    [Field("keyType")]
    public One<KeyType> KeyType { get; set; }

    [Field("sold")]
    public bool IsSold { get; set; }

    [Field("bought")]
    public bool IsBought { get; set; }

    [Field("price")]
    public double Price { get; set; }

    [Field("img")]
    public string Img { get; set; }

    [Field("description")]
    public string Description { get; set; }

    [Field("owner")]
    public ApplicationUser Owner { get; set; }

    [Field("startDate")]
    public DateTime StartDate { get; set; }

    [Field("endDate")]
    public DateTime EndDate { get; set; }

    public Key AddOwner(ApplicationUser owner)
    {
        Owner = owner;
        return this;
    }

}