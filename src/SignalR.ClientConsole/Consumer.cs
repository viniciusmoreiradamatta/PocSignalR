using Microsoft.AspNetCore.SignalR.Client;

namespace SignalR.Core;

public class Consumer : IAsyncDisposable
{
    private readonly string HostDomain = "https://localhost:7019/Notificao";

    private HubConnection _hubConnection;

    public Consumer()
    {
        _hubConnection = new HubConnectionBuilder().WithUrl(new Uri(HostDomain))
                                                   .WithAutomaticReconnect().Build();

        _hubConnection.On<Notification>("NotificationReceived", OnNotificationReceivedAsync);
    }

    public Task StartNotificationConnectionAsync() => _hubConnection.StartAsync();

    public async ValueTask DisposeAsync()
    {
        if (_hubConnection is not null)
        {
            await _hubConnection.DisposeAsync();
            _hubConnection = null;
        }
    }
    private async Task OnNotificationReceivedAsync(Notification notification)
    {
        Console.WriteLine($"Notificacao recebida: {notification.Text} - {notification.Date}");
    }
}