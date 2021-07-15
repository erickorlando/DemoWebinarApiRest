using DataAccess.Repositories;
using Dto.Request;
using Dto.Response;
using Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _repository;

        public CustomerService(ICustomerRepository repository)
        {
            _repository = repository;
        }

        public async Task<ICollection<DtoCustomerResponse>> ListAsync()
        {
            var collection = await _repository.ListCollectionAsync();

            return collection.Select(x => new DtoCustomerResponse
            {
                Id = x.Id,
                Name = x.Name,
                LastName = x.LastName,
                Email = x.Email,
                BirthDate = x.BirthDate
            })
            .ToList();
        }

        public async Task<DtoCustomerResponse> GetByIdAsync(int id)
        {
            var customer = await _repository.GetAsync(id);

            if (customer == null)
                return null;

            return new DtoCustomerResponse
            {
                Id = customer.Id,
                Name = customer.Name,
                LastName = customer.LastName,
                BirthDate = customer.BirthDate,
                Email = customer.Email
            };
        }



        public async Task<int> CreateAsync(DtoCustomerRequest request)
        {
            return await _repository.CreateAsync(new Customer
            {
                Name = request.Name,
                LastName = request.LastName,
                Email = request.Email,
                BirthDate = request.BirthDate,
            });
        }

        public async Task<int> UpdateAsync(int id, DtoCustomerRequest request)
        {
            return await _repository.UpdateAsync(new Customer
            {
                Id = id,
                Name = request.Name,
                LastName = request.LastName,
                Email = request.Email,
                BirthDate = request.BirthDate
            });
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }

        public async Task<ICollection<DtoCustomerDirections>> GetDirectionsAsync(int id)
        {
            var collection = await _repository.ListDirections(id);

            return collection.Select(p => new DtoCustomerDirections
            {
                Location = p.Location,
                Country = p.Country,
                Default = p.Default
            })
            .ToList();
        }
    }
}
