namespace kbc.question.service.Models;

public class MongoDbSettings
{
    public string Uri { get; set; } = null!;
    public string Database { get; set; } = null!;
    public string Collection { get; set; } = null!;
}
