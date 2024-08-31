using CRMDev.API.DTO.InputModels;
using CRMDev.API.Entities;
using CRMDev.API.Persistence;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<CRMContext>(options => options.UseInMemoryDatabase("CRMDatabase"));

var app = builder.Build();

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
    var forecast =  Enumerable.Range(1, 5).Select(index =>
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

app.MapGet("/api/contacts", (CRMContext context) => {
    var contacts = context.Contacts.ToList();

    return Results.Ok(contacts);
});

app.MapGet("/api/contacts/{id}", (Guid id, CRMContext context) => {
    var contact = context.Contacts.SingleOrDefault(c => c.Id == id);

    if(contact is null)
    {
        return Results.NotFound();
    }

    return Results.Ok(contact);
});

app.MapPost("/api/contacts", (CRMContext context, CreateContactInputModel model) => {
    var contact = new Contact(model.Name, model.Email);

    context.Add(contact);
    context.SaveChanges();

    return Results.Created($"/api/contacts/{contact.Id}", contact);
});

app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
