using SignalRPoc.Server;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSignalR();
builder.Services.AddScoped<NotificationService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapHub<NotificationHub>("Notificao");

app.MapGet("/Notificar", async (NotificationService _service) =>
    await _service.SendNotificationAsync(new("Notificando", DateTime.Now))
).WithName("Notificar");

app.Run();