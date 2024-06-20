using AspNetCore.Identity.MongoDbCore.Models;
using MongoDbGenericRepository.Attributes;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Entities;
using System.ComponentModel;

namespace KeyStore.Domain.Entities;

[CollectionName("Users")]
public class ApplicationUser : MongoIdentityUser<Guid>, IModifiedOn, IEntity
{
    public string? Name { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public override string? Email { get; set; }
    public List<Key> Keys { get; set; }

    [BsonElement("ApplicationUserRoles")]
    public List<string> Roles { get; set; }
    public double Balance { get; set; }

    public DateTime ModifiedOn { get; set; }
    public string GenerateNewID()
    {
        throw new NotImplementedException();
    }

    public string? ID { get; set; }

    public ApplicationUser()
    {

    }
}