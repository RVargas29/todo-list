using MongoDB.Bson.Serialization.Attributes;

namespace TodoList.Models
{
    public class Task
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; }
        public string Name {get; set; }
        public string User {get; set; }
    }
}