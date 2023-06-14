using AutoMapper;
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

        public ProductController(IMapper mapper, IProductRepository repository, ILogger<ProductController> logger)
        {
            _mapper = mapper;
            _repository = repository;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetProducts(CancellationToken token)
        {
            var products = await _repository.GetAllAsync(token);
            var result = _mapper.Map<IEnumerable<ProductDto>>(products);
            return Ok(result);
        }

        [HttpGet("{id}", Name = "GetProductById")]
        public async Task<ActionResult<ProductDto>> GetProductById(int id, CancellationToken token)
        {
            var product = await _repository.FindSingleAsync(id, token);

            if (product == null)
                return NotFound();

            return Ok(_mapper.Map<ProductDto>(product));
        }

        [HttpPost]
        public async Task<ActionResult<ProductDto>> CreateProduct(NewProductDto newProductDto, CancellationToken token)
        {
            var productModel = _mapper.Map<Product>(newProductDto);

            await _repository.AddAsync(productModel, token);

            await _repository.SaveChangesAsync(token);

            var productDto = _mapper.Map<ProductDto>(productModel);

            return CreatedAtRoute(nameof(GetProductById), new { Id = productDto.Id }, productDto);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> RemoveProduct(int id, CancellationToken token)
        {
            var product = await _repository.FindSingleAsync(id, token);

            if (product == null)
                return NotFound();

            _repository.Remove(product);
            await _repository.SaveChangesAsync(token);

            return Ok();
        }

        [HttpPatch]
        public async Task<ActionResult> UpdateProduct(UpdateProductDto updateProduct, CancellationToken token)
        {
            var product = await _repository.FindSingleAsync(updateProduct.Id, token);

            if (product == null)
                return NotFound();

            var updatedProduct = _mapper.Map<UpdateProductDto, Product>(updateProduct, product);

            _repository.Update(updatedProduct);

            await _repository.SaveChangesAsync(token);

            return Ok();
        }
    }
}