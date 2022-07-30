ConnectionFactory factory = new() { HostName = "localhost" };

using (IConnection connection = factory.CreateConnection())
using (IModel channel = connection.CreateModel())
{
    EventingBasicConsumer consumer = new(model: channel);

    consumer.Received += (sender, e) =>
    {
        ReadOnlyMemory<byte> body = e.Body;

        var message = JsonSerializer.Deserialize<SomeMessage>(body.ToArray());

        Console.WriteLine($"Received message: {message?.Text ?? "Null"}");
    };

    channel.BasicConsume(
        queue: "some-message-queue",
        autoAck: true,
        consumer);

    Console.WriteLine("Subscribed to the queue 'some-message-queue'");

    Console.ReadKey();
}