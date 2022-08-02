using kbc.question.service.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace kbc.question.service.Service;

public class MongoDBService
{
    private readonly IMongoCollection<Question> _collection;

    public MongoDBService(IOptions<MongoDbSettings> settings)
    {
        var client = new MongoClient(settings.Value.Uri);
        var database = client.GetDatabase(settings.Value.Database);
        _collection = database.GetCollection<Question>(settings.Value.Collection);
    }

    public async Task<IEnumerable<Question>> GetQuestionsAsync(IEnumerable<string> ids) =>
        await _collection.Find(c => ids.Contains(c.Id))
        .ToListAsync();

    public async Task<IEnumerable<Question>> AddQuestionsAsync(IEnumerable<Question> questions)
    {
        await _collection.InsertManyAsync(questions);
        return questions;
    }
}
