using System.Linq.Expressions;
using OrderService.Models;

namespace OrderService.Contracts
{
    public interface IOrderItemRepository
    {
        public Task<bool> SaveChangesAsync(CancellationToken token);

        public Task<IEnumerable<OrderItem>> GetAllAsync(CancellationToken token);

        public Task<IEnumerable<OrderItem>> FindAllAsync(Expression<Func<OrderItem, bool>> predicate, CancellationToken token);

        public Task<OrderItem?> FirsOrDefaultAsync(Expression<Func<OrderItem, bool>> predicate, CancellationToken token);

        public Task<OrderItem?> FindSingleAsync(int id, CancellationToken token);

        public void Update(OrderItem OrderItem);

        public void Remove(OrderItem OrderItem);

        public Task AddAsync(OrderItem OrderItem, CancellationToken token);
    }
}
