using Sale.Application.DTO.Products;
using Sale.Domain.Entity;

namespace Sale.Application.Services.Products
{
    public class ProductService : IProductService
    {
        public async Task<Guid> CreateAsync(AddOrUpdateProductDTO dto, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Product>> GetAllAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<IQueryable<Customer>> SearchAsync(string param, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<Guid> UpdateAsync(AddOrUpdateProductDTO dto, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
