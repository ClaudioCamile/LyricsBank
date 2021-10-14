using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
//using Newtonsoft.Json;

namespace TllApi.Models
{
    public class Songs
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("Name")]
        //[JsonProperty("Name")]
        public string Name { get; set; }

        public decimal SingerBand { get; set; }

        public string Category { get; set; }

        public string Songwriters { get; set; }

        public string Length { get; set; }
    }
}