using var client = new HttpClient() { BaseAddress = new Uri("https://localhost:7019/Notificar") };

while (true)
{
    await client.GetAsync("");
    Console.WriteLine("enviando atualizacao");
    await Task.Delay(10000);
}