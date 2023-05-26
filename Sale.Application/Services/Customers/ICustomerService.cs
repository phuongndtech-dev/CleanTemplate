using Sale.Application.DTO.Customers;
using Sale.Domain.Entity;

namespace Sale.Application.Services.Customers
{
    public interface ICustomerService
    {
        Task<IEnumerable<Customer>> GetAllAsync(CancellationToken cancellationToken);
        Task<Guid> CreateAsync(AddOrUpdateCustomerDTO customer, CancellationToken cancellationToken);
        Task<Guid> UpdateAsync(Customer customer, CancellationToken cancellationToken);
        Task DeleteAsync(Guid id, CancellationToken cancellationToken);
        Task<IQueryable<Customer>> SearchAsync(string @param, CancellationToken cancellationToken);
    }
}
