namespace HRMQ.Publishers.MassTransit.Presentation.Controllers;

[Produces(contentType: "application/json")]
[ApiController]
[Route(template: "[controller]")]
public class SomeMessageController : ControllerBase
{
    private readonly IPublishEndpoint _publishEndpoint;

    public SomeMessageController(IPublishEndpoint publishEndpoint)
    {
        _publishEndpoint = publishEndpoint;
    }

    [ProducesResponseType(statusCode: StatusCodes.Status200OK)]
    [HttpPost()]
    public async Task<ActionResult> Publish([FromBody] SomeMessage message)
    {
        if (message is null) return BadRequest();

        await _publishEndpoint.Publish(message);

        return Ok(message.Text);
    }
}