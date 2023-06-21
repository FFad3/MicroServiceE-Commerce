using BasketService.Contracts;
using ECommerce.Common;
using MassTransit;
using Newtonsoft.Json;

namespace BasketService.Consumers
{
    public class ProductItemDeletedConsumer : IConsumer<ProductItemDeleted>
    {
        private readonly IBasketRepository _basketRepository;
        private readonly ILogger<ProductItemDeletedConsumer> _logger;

        public ProductItemDeletedConsumer(IBasketRepository basketRepository, ILogger<ProductItemDeletedConsumer> logger)
        {
            _basketRepository = basketRepository;
            _logger = logger;
        }

        public async Task Consume(ConsumeContext<ProductItemDeleted> context)
        {
            var message = context.Message;
            _logger.LogInformation($"Message: {nameof(ProductItemDeleted)} recived payload={JsonConvert.SerializeObject(message)}");
            if (message is null)
            {
                _logger.LogWarning($"Message: {nameof(ProductItemDeleted)} was null");
                return;
            }
            await _basketRepository.RemoveProductDataAsync(message.Id.ToString());
        }
    }
}
