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
        public async Task<ActionResult<ShoppingCartReadDto>> GetBasket(string userId)
        {
            _logger.LogInformation("Retriving basket with id : {basketId}", userId);

            var basket = await _basketRepository.GetBasketAsync(userId);

            return Ok(_mapper.Map<ShoppingCartReadDto>(basket));
        }

        [HttpPost]
        public async Task<ActionResult<ShoppingCartReadDto>> UpdateBasket(ShoppingCartWriteDto basket)
        {
            _logger.LogInformation("Updating basket with id : {basketId}", basket.Id);

            var updatedBasket = _mapper.Map<ShoppingCart>(basket);

            var result = await _basketRepository.UpdateBasketAsync(updatedBasket);

            _logger.LogInformation("Basket has been updated", result);
            return Ok(_mapper.Map<ShoppingCartReadDto>(result));
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteBasket(string userId)
        {
            _logger.LogInformation("Deleting basket with id : {basketId}", userId);
            var basket = await _basketRepository.GetBasketAsync(userId);

            if (basket == null)
                return NotFound();

            await _basketRepository.DeleteBasketAsync(basket);

            _logger.LogInformation("Basket has been deleted");

            return Ok();
        }
    }
}