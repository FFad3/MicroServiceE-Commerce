using System.Text;
using AutoMapper;
using BasketService.Contracts;
using BasketService.Dtos;
using Messages.Messages;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace BasketService.Services
{
    public class ProductReciverService : BackgroundService
    {
        private readonly ConnectionFactory _factory;
        private readonly IConnection _conn;
        private readonly IModel _channel;
        private readonly IServiceProvider _sp;
        private readonly ILogger<ProductReciverService> _logger;

        public ProductReciverService(ILogger<ProductReciverService> logger, IServiceProvider sp)
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
            _sp = sp;
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            if (stoppingToken.IsCancellationRequested)
            {
                _channel.Dispose();
                _conn.Dispose();
                return Task.CompletedTask;
            }

            // create a consumer that listens on the channel (queue)
            var consumer = new EventingBasicConsumer(_channel);

            // handle the Received event on the consumer
            // this is triggered whenever a new message
            // is added to the queue by the producer
            consumer.Received += async (model, message) =>
            {
                // read the message bytes
                var body = message.Body.ToArray();
                var json = Encoding.UTF8.GetString(body);
                var conent = JsonConvert.DeserializeObject<UpdateProductMessage>(json);

                _logger.LogInformation("Message recived {0}", conent);

                if(conent is not null)
                {
                    using(var scope = _sp.CreateScope())
                    {
                        var basketRepo = scope.ServiceProvider.GetRequiredService<IBasketRepository>();
                        var mapper = scope.ServiceProvider.GetRequiredService<IMapper>();

                        var updatedProduct = mapper.Map<UpdateProductDto>(conent);

                        await basketRepo.UpdateProductDataAsync(updatedProduct, stoppingToken);
                        _logger.LogInformation("Product succesfully pudated");
                    }
                }
            };

            _channel.BasicConsume(queue: "Product", autoAck: true, consumer: consumer);

            return Task.CompletedTask;
        }
    }
}