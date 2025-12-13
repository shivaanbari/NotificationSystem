using Microsoft.OpenApi.Models;
using NotificationSystem.Interfaces;
using NotificationSystem.Services;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

var assembly = Assembly.GetExecutingAssembly();

var senderTypes = assembly.GetTypes()
    .Where(t => !t.IsAbstract && typeof(INotificationSender).IsAssignableFrom(t));

foreach (var type in senderTypes)
{
    builder.Services.AddSingleton(typeof(INotificationSender), type);
}

builder.Services.AddTransient<NotificationService>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Notification API",
        Version = "v1",
        Description = "Simple Notification System (Email, SMS, Push, WhatsApp)"
    });
});
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(
            new System.Text.Json.Serialization.JsonStringEnumConverter());
    });

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Notification API v1");
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
