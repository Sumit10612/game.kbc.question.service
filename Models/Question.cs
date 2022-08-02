using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace kbc.question.service.Models;

public class Question
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }
    public string Text { get; set; }
    public List<Option> Options { get; set; }
    public string Information { get; set; }
}
