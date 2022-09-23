using Rwe.App.Abstractions;
using Rwe.App.Entities;
using Rwe.App.Services.HttpClients;
using Rwe.App.Services.QueueClients;

namespace Rwe.App
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApp(this IServiceCollection services, IConfiguration configuration)
        {
            var section = configuration.GetSection(ConfigOptions.ConfigName);
            services.Configure<ConfigOptions>(options => section.Bind(options));

            services.AddScoped<IMessageProducer, RabbitMqClient>();
            services.AddHttpClient<IWindparkClient, WindparkClient>();

            return services;
        }
    }
}