using System.Linq.Expressions;
using OrderService.Models;

namespace OrderService.Contracts
{
    public interface IOrderRepository
    {
        public Task<bool> SaveChangesAsync(CancellationToken token);

        public Task<IEnumerable<Order>> GetAllAsync(CancellationToken token);

        public Task<IEnumerable<Order>> FindAllAsync(Expression<Func<Order, bool>> predicate, CancellationToken token);

        public Task<Order?> FirsOrDefaultAsync(Expression<Func<Order, bool>> predicate, CancellationToken token);

        public Task<Order?> FindSingleAsync(int id, CancellationToken token);

        public void Update(Order Order);

        public void Remove(Order Order);

        public Task AddAsync(Order Order,CancellationToken token);
    }
}
