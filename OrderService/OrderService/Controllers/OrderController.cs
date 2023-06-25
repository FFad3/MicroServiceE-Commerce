using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderService.Contracts;
using OrderService.Models;
using static MassTransit.ValidationResultExtensions;

namespace OrderService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IOrderRepository _repository;
        private readonly ILogger<OrderController> _logger;

        public OrderController(IMapper mapper, IOrderRepository repository, ILogger<OrderController> logger)
        {
            _mapper = mapper;
            _repository = repository;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Order>>> GetOrders(CancellationToken token)
        {
            _logger.LogInformation("Getting all orders");
            var orders = await _repository.GetAllAsync(token);
            _logger.LogInformation($"Recived {orders.Count()} orders");
            return Ok(orders);
        }
    }
}
