using System.Collections.Generic;
using System.Threading.Tasks;
using Entities;

namespace DataAccess.Repositories
{
    public interface ICustomerRepository
    {
        Task<ICollection<Customer>> ListCollectionAsync();

        Task<Customer> GetAsync(int id);

        Task<int> CreateAsync(Customer customer);

        Task<int> UpdateAsync(Customer customer);

        Task DeleteAsync(int id);

        Task<ICollection<Direction>> ListDirections(int id);
    }
}