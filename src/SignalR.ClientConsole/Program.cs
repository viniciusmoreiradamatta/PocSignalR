using SignalR.Core;

var consumer = new Consumer();

await consumer.StartNotificationConnectionAsync();

while (true)
{
    Console.WriteLine("Aguardando...");
    await Task.Delay(1000);
}