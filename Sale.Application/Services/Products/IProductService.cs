using Sale.Application.DTO.Customers;
using Sale.Application.DTO.Products;
using Sale.Domain.Entity;

namespace Sale.Application.Services.Products
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetAllAsync(CancellationToken cancellationToken);
        Task<Guid> CreateAsync(AddOrUpdateProductDTO dto, CancellationToken cancellationToken);
        Task<Guid> UpdateAsync(AddOrUpdateProductDTO dto, CancellationToken cancellationToken);
        Task DeleteAsync(Guid id, CancellationToken cancellationToken);
        Task<IQueryable<Customer>> SearchAsync(string @param, CancellationToken cancellationToken);
    }
}
