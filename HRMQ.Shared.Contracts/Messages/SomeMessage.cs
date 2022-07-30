namespace HRMQ.Shared.Contracts.Messages;

public record class SomeMessage
{
    public string Text { get; init; } = string.Empty;

    public SomeMessage(string text) => Text = text;
}