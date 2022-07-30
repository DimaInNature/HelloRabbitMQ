ConnectionFactory factory = new() { HostName = "localhost" };

using (IConnection connection = factory.CreateConnection())
using (IModel channel = connection.CreateModel())
{
    SomeMessage message = new(text: "Hello");

    byte[] body = Encoding.UTF8.GetBytes(s: JsonSerializer.Serialize(message));

    channel.BasicPublish(
        exchange: "",
        routingKey: "some-message-queue",
        basicProperties: null,
        body);

    Console.WriteLine(value: "Message is sent into Default exchange");

    Console.ReadKey();
}