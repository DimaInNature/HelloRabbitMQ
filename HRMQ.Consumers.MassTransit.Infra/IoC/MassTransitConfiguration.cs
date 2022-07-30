namespace HRMQ.Consumers.MassTransit.Infra.IoC;

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
            config.AddConsumer<SomeMessageCommandHandler>();

            config.UsingRabbitMq(configure: (busContext, busConfigurator) =>
            {
                busConfigurator.Host(host: configuration[key: "RabbitMQ:Host"]);

                busConfigurator.ReceiveEndpoint(
                    queueName: configuration[key: "RabbitMQ:Endpoints:SomeMessageConsumer"],
                    configureEndpoint: configure =>
                    {
                        configure.UseRawJsonSerializer();
                        configure.ConfigureConsumer<SomeMessageCommandHandler>(registration: busContext);
                    });
            });
        });
    }
}