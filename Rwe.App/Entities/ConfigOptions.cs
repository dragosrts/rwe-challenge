namespace Rwe.App.Entities
{
    public class ConfigOptions
    {
        public const string ConfigName = "ConfigOptions";

        public string WindparkApiLink { get; set; } = string.Empty;

        public string RabbitMqQueueName { get; set; } = string.Empty;
    }
}