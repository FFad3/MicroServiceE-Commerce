using AutoMapper;
using BasketService.Contracts;
using BasketService.Dtos;
using ECommerce.Common;
using MassTransit;
using Newtonsoft.Json;

namespace BasketService.Consumers
{
    public class ProductItemUpdatedConsumer : IConsumer<ProductItemUpdated>
    {
        private readonly IBasketRepository _basketRepository;
        private readonly ILogger<ProductItemUpdatedConsumer> _logger;
        private readonly IMapper _mapper;

        public ProductItemUpdatedConsumer(IBasketRepository basketRepository, ILogger<ProductItemUpdatedConsumer> logger, IMapper mapper)
        {
            _basketRepository = basketRepository;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task Consume(ConsumeContext<ProductItemUpdated> context)
        {
            var message = context.Message;
            _logger.LogInformation($"Message: {nameof(ProductItemUpdated)} recived payload={JsonConvert.SerializeObject(message)}");
            if (message is null)
            {
                _logger.LogWarning($"Message: {nameof(ProductItemUpdated)} was null");
                return;
            }
            var updatedProduct = _mapper.Map<UpdateProductDto>(message);
                       
            await _basketRepository.UpdateProductDataAsync(updatedProduct);
        }
    }
}
