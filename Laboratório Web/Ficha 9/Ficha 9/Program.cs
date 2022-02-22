using System.Diagnostics;
using Ficha_9;

var builder = WebApplication.CreateBuilder(args);

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

app.MapGet("/", () =>
{
    return Results.Ok("Default");
});

app.MapDelete("/", () =>
{
    return Results.Ok("Delete");
});
app.Use(async (context, next) =>
{
    Debug.WriteLine("Before first middleware");
    await next.Invoke();
    
    Debug.WriteLine("After first middleware");
});

app.Use(async (context, next) =>
{
    Debug.WriteLine("Before second middleware");
    await next.Invoke();
    Debug.WriteLine("After second middleware");
});

app.UseCustomMiddleware();

app.UseLoggerMiddleware();

app.Run();

