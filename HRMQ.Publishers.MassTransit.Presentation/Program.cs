var builder = WebApplication.CreateBuilder(args);

RegisterServices(services: builder.Services);

var app = builder.Build();

Configure(app);

app.Run();

void RegisterServices(IServiceCollection services)
{
    services.AddCors();

    services.AddSwaggerConfiguration();

    services.AddMassTransitConfiguration(configuration: builder.Configuration);

    services.AddControllers();
}

void Configure(WebApplication app)
{
    app.UseHttpsRedirection();

    app.UseCors(cors =>
    {
        cors.AllowAnyHeader();
        cors.AllowAnyMethod();
        cors.AllowAnyOrigin();
    });

    app.MapControllers();

    app.UseSwaggerSetup();
}