using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using OrderService.Contracts;
using OrderService.Models;

namespace OrderService.Data
{
    public class OrderItemRepository : IOrderItemRepository
    {
        private readonly DbSet<OrderItem> _items;
        private readonly AppDbContext _appDbContext;

        public OrderItemRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
            _items = appDbContext.OrderItems;
        }

        public async Task AddAsync(OrderItem orderItem, CancellationToken token)
        {
            await _items.AddAsync(orderItem, token);
        }

        public async Task<IEnumerable<OrderItem>> GetAllAsync(CancellationToken token)
        {
            return await _items.ToListAsync(token);
        }

        public async Task<IEnumerable<OrderItem>> FindAllAsync(Expression<Func<OrderItem, bool>> predicate, CancellationToken token)
        {
            return await _items.Where(predicate).ToListAsync(token);
        }

        public void Remove(OrderItem product)
        {
            _items.Remove(product);
        }

        public void Update(OrderItem product)
        {
            _items.Update(product);
        }

        public async Task<OrderItem?> FirsOrDefaultAsync(Expression<Func<OrderItem, bool>> predicate, CancellationToken token)
        {
            return await _items.FirstOrDefaultAsync(predicate, token);
        }

        public async Task<OrderItem?> FindSingleAsync(int id, CancellationToken token)
        {
            return await _items.FindAsync(id, token);
        }

        public async Task<bool> SaveChangesAsync(CancellationToken token) => await _appDbContext.SaveChangesAsync(token) > 0;

    }
}
