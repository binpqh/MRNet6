using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Models
{
    public class RefreshToken
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId Id { get; set; }
        [BsonElement("refreshTokenString")]
        public string? RefreshTokenString { get; set; }
        [BsonElement("userId")]
        public string UserId { get; set; } = null!;
        [BsonElement("jwtTokenId")]
        public string? JwtTokenId { get; set; }
        [BsonElement("ipAddress")]
        public string? IpAddress { get; set; }
    }
}
