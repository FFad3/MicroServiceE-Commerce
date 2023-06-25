using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using OrderService.Contracts;
using OrderService.Models;

namespace OrderService.Data
{
    public class OrderRepository : IOrderRepository
    {
        private readonly DbSet<Order> _items;
        private readonly AppDbContext _appDbContext;

        public OrderRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
            _items = appDbContext.Orders;
        }

        public async Task AddAsync(Order order, CancellationToken token)
        {
            await _items.AddAsync(order, token);
        }

        public async Task<IEnumerable<Order>> GetAllAsync(CancellationToken token)
        {
            return await _items.Include(c => c.Items).ToListAsync(token);
        }

        public async Task<IEnumerable<Order>> FindAllAsync(Expression<Func<Order, bool>> predicate, CancellationToken token)
        {
            return await _items.Include(c => c.Items).Where(predicate).ToListAsync(token);
        }

        public void Remove(Order order)
        {
            _items.Remove(order);
        }

        public void Update(Order order)
        {
            _items.Update(order);
        }

        public async Task<Order?> FirsOrDefaultAsync(Expression<Func<Order, bool>> predicate, CancellationToken token)
        {
            return await _items.Include(c => c.Items).FirstOrDefaultAsync(predicate, token);
        }

        public async Task<Order?> FindSingleAsync(int id, CancellationToken token)
        {
            return await _items.FindAsync(id, token);
        }

        public async Task<bool> SaveChangesAsync(CancellationToken token) => await _appDbContext.SaveChangesAsync(token) > 0;
    }
}