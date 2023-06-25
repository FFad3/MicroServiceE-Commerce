using AutoMapper;
using ECommerce.Common;
using MassTransit;
using Newtonsoft.Json;
using OrderService.Contracts;
using OrderService.Models;

namespace OrderService.Consumers
{
    public class OrderPlacedConsumer : IConsumer<OrderPlaced>
    {
        private readonly IOrderRepository _repo;
        private readonly ILogger<OrderPlacedConsumer> _logger;
        private readonly IMapper _mapper;

        public OrderPlacedConsumer(IOrderRepository repo, ILogger<OrderPlacedConsumer> logger, IMapper mapper)
        {
            _repo = repo;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task Consume(ConsumeContext<OrderPlaced> context)
        {
            var message = context.Message;
            _logger.LogInformation($"Message: {nameof(OrderPlaced)} recived payload={JsonConvert.SerializeObject(message)}");
            if (message is null)
            {
                _logger.LogWarning($"Message: {nameof(OrderPlaced)} was null");
                return;
            }
            var newOrder = _mapper.Map<Order>(message);

            await _repo.AddAsync(newOrder,CancellationToken.None);
            await _repo.SaveChangesAsync(CancellationToken.None);
        }
    }
}
