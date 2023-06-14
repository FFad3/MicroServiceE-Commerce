using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using ProductService.Contracts;
using ProductService.Models;

namespace ProductService.Data
{
    public class ProductRepository : IProductRepository
    {
        private readonly DbSet<Product> _products;
        private readonly AppDbContext _appDbContext;

        public ProductRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
            _products = appDbContext.Products;
        }

        public async Task AddAsync(Product product, CancellationToken token)
        {
            await _products.AddAsync(product, token);
        }

        public async Task<IEnumerable<Product>> GetAllAsync(CancellationToken token)
        {
            return await _products.ToListAsync(token);
        }

        public async Task<IEnumerable<Product>> FindAllAsync(Expression<Func<Product, bool>> predicate, CancellationToken token)
        {
            return await _products.Where(predicate).ToListAsync(token);
        }

        public void Remove(Product product)
        {
            _products.Remove(product);
        }

        public void Update(Product product)
        {
            _products.Update(product);
        }

        public async Task<Product?> FirsOrDefaultAsync(Expression<Func<Product, bool>> predicate, CancellationToken token)
        {
            return await _products.FirstOrDefaultAsync(predicate, token);
        }

        public async Task<Product?> FindSingleAsync(int id, CancellationToken token)
        {
            return await _products.FindAsync(id, token);
        }

        public async Task<bool> SaveChangesAsync(CancellationToken token) => await _appDbContext.SaveChangesAsync(token) > 0;
    }
}