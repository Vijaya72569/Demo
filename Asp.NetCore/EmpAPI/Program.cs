using Microsoft.Data.SqlClient;
using System.Data;
using EmpAPI.Models;
using System.ComponentModel.DataAnnotations;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

var constring = builder.Configuration.GetConnectionString("getcon");

app.MapGet("api/Emp", () =>
{
 List<Emp> emps = new List<Emp>();
    SqlConnection con = new SqlConnection(constring);
    con.Open();
    string query = "select * from emp";
    SqlCommand cmd = new SqlCommand(query, con);
    cmd.CommandType = CommandType.Text;
    SqlDataReader reader = cmd.ExecuteReader();
    while (reader.Read())
    {
        emps.Add(new Emp()
        {
            Id=Convert.ToInt32(reader["id"]),
            Name = reader["Name"].ToString(),
            Salary = Convert.ToDecimal(reader["Salary"]),
            Phone = Convert.ToInt64(reader["Phone"])

        });
    }
    return Results.Ok(emps);
});
app.MapGet("api/Emp/{id}",(int id)=>
{

Emp emp = new Emp();
SqlConnection con = new SqlConnection(constring);
con.Open();
string query = "select * from emp where Id=@id";
SqlCommand cmd = new SqlCommand(query, con);
cmd.CommandType = CommandType.Text;
cmd.Parameters.AddWithValue("@id", id);

SqlDataReader reader = cmd.ExecuteReader();
    while (reader.Read())
    {
        emp = new()
        {
            Id = Convert.ToInt32(reader["id"]),
            Name = reader["Name"].ToString(),
            Salary = Convert.ToDecimal(reader["Salary"]),
            Phone = Convert.ToInt64(reader["Phone"])
        };
    }
    return Results.Ok(emp);

});
app.MapPost("api/Emp", (Emp em) =>
{
SqlConnection con=new SqlConnection(constring);
    string query = "Insert into Emp (Name,Salary,Phone) Values(@name,@sal,@phno)";
    SqlCommand cmd= new SqlCommand(query, con);
    cmd.CommandType = CommandType.Text;
    cmd.Parameters.AddWithValue("@name", em.Name);
    cmd.Parameters.AddWithValue("@sal", em.Salary);
    cmd.Parameters.AddWithValue("@phno", em.Phone);
    con.Open();
    int rows=cmd.ExecuteNonQuery();
    return rows > 0 ? Results.Ok("Insert Successfully") : Results.NotFound("Not Insert");
});
app.MapPut("api/Emp/{id}", (Emp em,int id) =>
{
    SqlConnection con = new SqlConnection(constring);
    string query = "Update Emp Set Name=@name,Salary=@sal,Phone=@phno where Id=@id";
    SqlCommand cmd = new SqlCommand(query, con);
    cmd.CommandType = CommandType.Text;
    cmd.Parameters.AddWithValue("@id", id);
    cmd.Parameters.AddWithValue("@name", em.Name);
    cmd.Parameters.AddWithValue("@sal", em.Salary);
    cmd.Parameters.AddWithValue("@phno", em.Phone);
    con.Open();
    int rows = cmd.ExecuteNonQuery();
    return rows > 0 ? Results.Ok("Update Successfully") : Results.NotFound("Not Update");
}
);
app.MapDelete("api/Emp/{id}", (int id) =>
{
    SqlConnection con = new SqlConnection(constring);
    string query = "Delete from Emp where Id=@id";
    SqlCommand cmd = new SqlCommand(query, con);
    cmd.CommandType = CommandType.Text;
    cmd.Parameters.AddWithValue("@id", id);
    
    con.Open();
    int rows = cmd.ExecuteNonQuery();
    return rows > 0 ? Results.Ok("Delete Successfully") : Results.NotFound("Not Delete");
});
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
