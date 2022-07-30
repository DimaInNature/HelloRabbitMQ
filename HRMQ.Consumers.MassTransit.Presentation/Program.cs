var builder = WebApplication.CreateBuilder(args);

RegisterServices(services: builder.Services);

builder.Build().Run();

void RegisterServices(IServiceCollection services)
{
    services.AddMediatRConfiguration();

    services.AddMassTransitConfiguration(configuration: builder.Configuration);
}