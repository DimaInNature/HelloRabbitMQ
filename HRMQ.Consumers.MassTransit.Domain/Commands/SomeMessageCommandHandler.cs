namespace HRMQ.Consumers.MassTransit.Domain.Commands;

public class SomeMessageCommandHandler : IConsumer<SomeMessage>
{
    private readonly ILogger<SomeMessageCommandHandler> _logger;

    public SomeMessageCommandHandler(ILogger<SomeMessageCommandHandler> logger) =>
        _logger = logger;

    public async Task Consume(ConsumeContext<SomeMessage> context)
    {
        await Console.Out.WriteLineAsync(value: context.Message.Text);

        _logger.LogInformation(message: $"New some message {context.Message.Text}");
    }
}