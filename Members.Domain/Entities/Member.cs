using MongoDB.Bson.Serialization.Attributes;

namespace Members.Domain.Entities
{
    [BsonCollection("Member")]
    public class Member : Base
    {
        [BsonElement("name")]
        [BsonRepresentation(MongoDB.Bson.BsonType.String)]
        public string Name { get; set; }

        [BsonElement("surname")]
        [BsonRepresentation(MongoDB.Bson.BsonType.String)]
        public string Surname { get; set; }

        [BsonElement("email")]
        [BsonRepresentation(MongoDB.Bson.BsonType.String)]
        public string Email { get; set; }

    }
}
