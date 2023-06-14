using System.Linq.Expressions;
using ProductService.Models;

namespace ProductService.Contracts
{
    public interface IProductRepository
    {
        public Task<bool> SaveChangesAsync(CancellationToken token);

        public Task<IEnumerable<Product>> GetAllAsync(CancellationToken token);

        public Task<IEnumerable<Product>> FindAllAsync(Expression<Func<Product, bool>> predicate, CancellationToken token);

        public Task<Product?> FirsOrDefaultAsync(Expression<Func<Product, bool>> predicate, CancellationToken token);

        public Task<Product?> FindSingleAsync(int id, CancellationToken token);

        public void Update(Product product);

        public void Remove(Product product);

        public Task AddAsync(Product product, CancellationToken token);
    }
}