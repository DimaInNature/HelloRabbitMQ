namespace HRMQ.Publishers.MassTransit.Infra.IoC;

public static class MassTransitConfiguration
{
    public static void AddMassTransitConfiguration(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        ArgumentNullException.ThrowIfNull(argument: services);

        ArgumentNullException.ThrowIfNull(argument: configuration);

        services.AddMassTransit(configure: config =>
        {
            config.UsingRabbitMq(configure: (busContext, busConfigurator) =>
            {
                busConfigurator.Host(host: configuration[key: "RabbitMQ:Host"]);

                busConfigurator.ReceiveEndpoint(
                     queueName: configuration[key: "RabbitMQ:Endpoints:SomeMessagePublisher"],
                     configureEndpoint: configure =>
                     {
                         configure.UseRawJsonSerializer();
                         configure.Bind<SomeMessage>();
                     });
            });
        });

    }
}