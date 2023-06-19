using AutoMapper;
using Messages.Messages;
using Microsoft.AspNetCore.Mvc;
using ProductService.Contracts;
using ProductService.Dtos;
using ProductService.Models;

namespace ProductService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IProductRepository _repository;
        private readonly ILogger<ProductController> _logger;
        private readonly IMessageProducer _messageProducer;

        public ProductController(IMapper mapper, IProductRepository repository, ILogger<ProductController> logger, IMessageProducer messageProducer)
        {
            _mapper = mapper;
            _repository = repository;
            _logger = logger;
            _messageProducer = messageProducer;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetProducts(CancellationToken token)
        {
            _logger.LogInformation("Gettiing all products");
            var products = await _repository.GetAllAsync(token);
            var result = _mapper.Map<IEnumerable<ProductDto>>(products);
            _logger.LogInformation($"Recived {result.Count()} products");
            return Ok(result);
        }

        [HttpGet("{id}", Name = "GetProductById")]
        public async Task<ActionResult<ProductDto>> GetProductById(int id, CancellationToken token)
        {
            _logger.LogInformation($"Getting product with id:{id}");
            var product = await _repository.FindSingleAsync(id, token);
            _logger.LogInformation("Recived product", product);
            if (product == null)
            {
                _logger.LogInformation($"Product with id:{id} not found");
                return NotFound();
            }

            return Ok(_mapper.Map<ProductDto>(product));
        }

        [HttpPost]
        public async Task<ActionResult<ProductDto>> CreateProduct(NewProductDto newProductDto, CancellationToken token)
        {
            _logger.LogInformation("Creating new product", newProductDto);
            var productModel = _mapper.Map<Product>(newProductDto);

            await _repository.AddAsync(productModel, token);

            await _repository.SaveChangesAsync(token);
            _logger.LogInformation($"Created new product with id:{productModel.Id}");

            var productDto = _mapper.Map<ProductDto>(productModel);

            return CreatedAtRoute(nameof(GetProductById), new { Id = productDto.Id }, productDto);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> RemoveProduct(int id, CancellationToken token)
        {
            _logger.LogInformation($"Removing product with id:{id}");
            var product = await _repository.FindSingleAsync(id, token);

            if (product == null)
            {
                _logger.LogInformation($"Product with id:{id} not found");
                return NotFound();
            }

            _repository.Remove(product);
            await _repository.SaveChangesAsync(token);
            _logger.LogInformation($"Removed product with id:{id}");
            return Ok();
        }

        [HttpPatch]
        public async Task<ActionResult> UpdateProduct(UpdateProductDto updateProduct, CancellationToken token)
        {
            _logger.LogInformation($"Updating product with", updateProduct);
            var product = await _repository.FindSingleAsync(updateProduct.Id, token);

            if (product == null)
            {
                _logger.LogInformation($"Product with id:{updateProduct.Id} not found");
                return NotFound();
            }
            var updatedProduct = _mapper.Map<UpdateProductDto, Product>(updateProduct, product);

            _repository.Update(updatedProduct);

            await _repository.SaveChangesAsync(token);
            _logger.LogInformation($"Updated product with id:{product.Id}");

            _logger.LogInformation("Publishing message to Queue");
            await _messageProducer.SendMessage(_mapper.Map<UpdateProductMessage>(updatedProduct));

            return Ok();
        }
    }
}