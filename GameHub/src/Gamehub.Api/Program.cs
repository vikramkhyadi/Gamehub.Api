using Gamehub.Api;
using Gamehub.Api.Database;
using Gamehub.Api.Middlewares;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);
builder.Logging.ClearProviders();
builder.Logging.AddConsole();


var connString = builder.Configuration.GetSection("ConnectionStrings").Value;
if (DatabaseMigrationHelper.ShouldRunDatabaseMigration())
{
    DatabaseMigrationHelper.RunDatabaseMigration(builder.Configuration);
}

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = $"{Constants.ApiVersions.V1}",
        Title = $"Games API - {Constants.ApiVersions.V1}",
        Description = $"Endpoints for online gaming  - {Constants.ApiVersions.V1}",
        Contact = new OpenApiContact
        {
            Name = "Vikram Khyadi",
            Email = "vikramkhyadi@gmail.com",
        },

    });
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);
});
builder.Services.AddApiVersioning(options =>
{
    options.DefaultApiVersion = new ApiVersion(1, 0);
    options.AssumeDefaultVersionWhenUnspecified = true;
    options.ReportApiVersions = true;
});
builder.Services.AddApplication(connString);
var app = builder.Build();

// Configure the HTTP request pipeline.

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseMiddleware<RequestLoggingMiddleware>();
app.UseHttpsRedirection();
app.UseMiddleware<ExceptionMiddleware>();

app.UseApiVersioning();
app.UseAuthorization();
app.MapControllers();
app.Run();
