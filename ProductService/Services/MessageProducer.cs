using System.Text;
using Newtonsoft.Json;
using ProductService.Contracts;
using RabbitMQ.Client;

namespace ProductService.Services
{
    public class MessageProducer : IMessageProducer
    {
        private readonly ConnectionFactory _factory;
        private readonly IConnection _conn;
        private readonly IModel _channel;
        private readonly ILogger<MessageProducer> _logger;

        public MessageProducer(ILogger<MessageProducer> logger)
        {
            _logger = logger;


            _factory = new ConnectionFactory()
            {
                HostName = "rabbitmq",
                Port = 5672,

                UserName = "guest",
                Password = "guest",
            };

            _logger.LogInformation("Connecting to rabbitMq");
            _conn = _factory.CreateConnection();
            _logger.LogInformation("Connected to rabbitMq");

            _logger.LogInformation("Creating Channel");
            _channel = _conn.CreateModel();
            _logger.LogInformation("Channel created");

            _logger.LogInformation("Declaring Queue");
            _channel.QueueDeclare(queue: "Product",
                                    durable: true,
                                    exclusive: false,
                                    autoDelete: false,
                                    arguments: null);
            _logger.LogInformation("Product Queue declared");
        }

        public Task SendMessage<T>(T message)
        {
            var json = JsonConvert.SerializeObject(message);
            var body = Encoding.UTF8.GetBytes(json);

            _channel.BasicPublish(exchange: "", routingKey: "Product", body: body);

            _logger.LogInformation("[x] Published {message} to RabbitMQ", body);
            return Task.CompletedTask;
        }
    }
}