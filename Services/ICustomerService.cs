using System.Collections.Generic;
using System.Threading.Tasks;
using Dto.Request;
using Dto.Response;

namespace Services
{
    public interface ICustomerService
    {
        Task<ICollection<DtoCustomerResponse>> ListAsync();

        Task<DtoCustomerResponse> GetByIdAsync(int id);

        Task<int> CreateAsync(DtoCustomerRequest request);

        Task<int> UpdateAsync(int id, DtoCustomerRequest request);

        Task DeleteAsync(int id);
        Task<ICollection<DtoCustomerDirections>> GetDirectionsAsync(int id);
    }
}