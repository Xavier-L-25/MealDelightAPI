using MealDelightAPI.Controllers.Entities;
using MealDelightAPI.Data;
using Microsoft.EntityFrameworkCore;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.



builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Added Section
var connection = String.Empty;
if (builder.Environment.IsDevelopment())
{
    builder.Configuration.AddEnvironmentVariables().AddJsonFile("appsettings.json");
    connection = builder.Configuration.GetConnectionString("AZURE_SQL_CONNECTIONSTRING");
}
else
{
    connection = Environment.GetEnvironmentVariable("AZURE_SQL_CONNECTIONSTRING");
}

builder.Services.AddDbContext<DataContext>(options =>
    options.UseSqlServer(connection));
////////
///
builder.Services.AddCors(options =>
{
    options.AddPolicy("NextjsUI", policyBuilder =>
    {
        policyBuilder.WithOrigins("http://localhost:3000");
        policyBuilder.AllowAnyHeader();
        policyBuilder.AllowAnyMethod();
        policyBuilder.AllowCredentials();
    });
});
/////////

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("NextjsUI");

app.UseAuthorization();

app.MapControllers();

// Added Section
app.MapGet("/Person", (DataContext context) =>
{
    return context.Person.ToList();
})
.WithName("GetPersons");

app.MapPost("/Person", (Person person, DataContext context) =>
{
    context.Add(person);
    context.SaveChanges();
})
.WithName("CreatePerson");
/////////

app.Run();
