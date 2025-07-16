using WebApiCoreSwagger8ltm.Models;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
// add code


// 🔹 In-memory List
List<Todo> todos = new()
{
    new Todo { Id = 1, Title = "Learn .NET 8", IsCompleted = false },
    new Todo { Id = 2, Title = "Build Minimal API", IsCompleted = true }
};

// 🔸 Get All Tasks
app.MapGet("/api/todos", () => todos);

// 🔸 Get Task by Id
app.MapGet("/api/todos/{id}", (int id) =>
{
    var todo = todos.FirstOrDefault(t => t.Id == id);
    return todo is not null ? Results.Ok(todo) : Results.NotFound("Task not found.");
});

// 🔸 Create New Task
app.MapPost("/api/todos", (Todo todo) =>
{
    todo.Id = todos.Any() ? todos.Max(t => t.Id) + 1 : 1;
    todos.Add(todo);
    return Results.Created($"/api/todos/{todo.Id}", todo);
});

// 🔸 Update Task
app.MapPut("/api/todos/{id}", (int id, Todo updated) =>
{
    var todo = todos.FirstOrDefault(t => t.Id == id);
    if (todo is null) return Results.NotFound("Task not found.");

    todo.Title = updated.Title;
    todo.IsCompleted = updated.IsCompleted;
    return Results.Ok(todo);
});

// 🔸 Delete Task
app.MapDelete("/api/todos/{id}", (int id) =>
{
    var todo = todos.FirstOrDefault(t => t.Id == id);
    if (todo is null) return Results.NotFound("Task not found.");

    todos.Remove(todo);
    return Results.Ok($"Task with ID {id} deleted.");
});

//add code last


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
{
    var forecast = Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
})
.WithName("GetWeatherForecast")
.WithOpenApi();

app.Run();

internal record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
