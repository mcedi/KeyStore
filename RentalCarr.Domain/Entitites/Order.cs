using KeyStore.Domain.Common;
using MongoDB.Entities;
using KeyStore.Domain.Common;
using KeyStore.Domain.Entities;

namespace KeyStore.Domain.Entities;

[Collection("orders")]
public class Order : AuditableEntity
{
    public ApplicationUser Customer { get; set; }

    public List<Key> Keys { get; set; }

    public string Status { get; set; }

    public double TotalPrice { get; set; }

    public long OrderCode { get; set; }

    public Order()
    {
    }

    public Order CalculateTotalPrice()
    {
        TotalPrice = this.Keys.Sum(l => l.Price);
        return this;
    }
}