using MongoDB.Bson.Serialization.Attributes;

namespace Members.Domain.Entities
{
    [BsonCollection("User")]
    public class User : Base
    {
        [BsonElement("userName")]
        [BsonRepresentation(MongoDB.Bson.BsonType.String)]
        public string UserName { get; set; }

        [BsonElement("password")]
        [BsonRepresentation(MongoDB.Bson.BsonType.String)]
        public string Password { get; set; }

        [BsonElement("member_id")]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string MemberId { get; set; }
    }
}
