using AutoMapper;
using BasketService.Contracts;
using BasketService.Dtos;
using BasketService.Models;
using Microsoft.AspNetCore.Mvc;

namespace BasketService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly ILogger<BasketController> _logger;
        private readonly IBasketRepository _basketRepository;
        private readonly IMapper _mapper;

        public BasketController(ILogger<BasketController> logger, IBasketRepository basketRepository, IMapper mapper)
        {
            _logger = logger;
            _basketRepository = basketRepository;
            _mapper = mapper;
        }

        [HttpGet("{userId}", Name = "GetBasket")]
        public async Task<ActionResult<ShoppingCartDto>> GetBasket(string userId, CancellationToken token)
        {
            _logger.LogInformation("Retriving basket with id : {basketId}", userId);

            var basket = await _basketRepository.GetBasketAsync(userId, token);

            return Ok(_mapper.Map<ShoppingCartDto>(basket));
        }

        [HttpPost]
        public async Task<ActionResult<ShoppingCartDto>> UpdateBasket(ShoppingCartDto basket, CancellationToken token)
        {
            _logger.LogInformation("Updating basket with id : {basketId}", basket.Id);

            var updatedBasket = _mapper.Map<ShoppingCart>(basket);

            var result = await _basketRepository.UpdateBasketAsync(updatedBasket, token);

            _logger.LogInformation("Basket has been updated", result);
            return Ok(_mapper.Map<ShoppingCartDto>(result));
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteBasket(string userId, CancellationToken token)
        {
            _logger.LogInformation("Deleting basket with id : {basketId}", userId);

            await _basketRepository.DeleteBasketAsync(userId, token);

            _logger.LogInformation("Basket has been deleted");

            return Ok();
        }
    }
}