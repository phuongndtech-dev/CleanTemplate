using Sale.Application.DTO.Customers;
using Sale.Domain.Entity;

namespace Sale.Application.Services.Customers
{
    public interface ICustomerService
    {
        Task<IEnumerable<Customer>> GetAllAsync(CancellationToken cancellationToken);
        Task<Guid> CreateAsync(AddOrUpdateCustomerDTO dto, CancellationToken cancellationToken);
        Task<Guid> UpdateAsync(AddOrUpdateCustomerDTO dto, CancellationToken cancellationToken);
        Task DeleteAsync(Guid id, CancellationToken cancellationToken);
        Task<IEnumerable<Customer>> SearchAsync(string @param, CancellationToken cancellationToken);
    }
}
