using Microsoft.AspNetCore.Identity.Data;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Backend.Domain.Entities;

public class User(string email, string password)
{
    [BsonId]
    [BsonRepresentation(BsonType.String)]
    public string Email { get; set; } = email;
    public string Password { get; set; } = password;
    public Guid? Id { get; set; }

    public static User FromRegisterRequest(RegisterRequest registerRequest)
    {
        return new User(registerRequest.Email, registerRequest.Password)
        {
            Id = Guid.NewGuid()
        };
    }
    
}