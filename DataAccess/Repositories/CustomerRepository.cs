using Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly DemoWebinarDbContext _context;

        public CustomerRepository(DemoWebinarDbContext context)
        {
            _context = context;
        }

        public async Task<ICollection<Customer>> ListCollectionAsync()
        {
            return await _context.Set<Customer>()
                .ToListAsync();
        }

        public async Task<Customer> GetAsync(int id)
        {
            return await _context.Set<Customer>()
                .Where(x => x.Id == id)
                .SingleOrDefaultAsync();
        }

        public async Task<int> CreateAsync(Customer customer)
        {
            await _context.Set<Customer>().AddAsync(customer);
            await _context.SaveChangesAsync();

            return customer.Id;
        }

        public async Task<int> UpdateAsync(Customer customer)
        {
            _context.Set<Customer>().Attach(customer);
            _context.Entry(customer).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return customer.Id;
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.Set<Customer>()
                .SingleOrDefaultAsync(p => p.Id == id);

            if (entity != null)
            {
                _context.Set<Customer>().Attach(entity);
                _context.Entry(entity).State = EntityState.Deleted;
                await _context.SaveChangesAsync();
            }
        }

        public async Task<ICollection<Direction>> ListDirections(int id)
        {
            return await _context.Set<Direction>()
                .Where(p => p.CustomerId == id)
                .ToListAsync();
        }
    }
}
