using kbc.question.service.Models;
using kbc.question.service.Service;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<MongoDbSettings>(builder.Configuration.GetSection("MongoDB"));
builder.Services.AddSingleton<MongoDBService>();

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.MapPost("/get", async ([FromBody]IEnumerable<string> ids, MongoDBService service) =>
    Results.Ok(await service.GetQuestionsAsync(ids)))
.WithName("GetQuestions");

app.MapPost("/post", async ([FromBody]IEnumerable<Question> questions, MongoDBService service) =>
{
    await service.AddQuestionsAsync(questions);
    return Results.Created("", questions.Select(q => q.Id));
}).WithName("AddQuestions");

app.Run();