using Microsoft.AspNetCore.SignalR;
using SignalR.Core;

namespace SignalRPoc.Server;

public class NotificationHub : Hub
{
    public Task Notify(Notification notification) =>
        Clients.All.SendAsync("NotificationReceived", notification);
}
