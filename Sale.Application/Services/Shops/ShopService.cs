using Sale.Application.DTO.Shops;
using Sale.Domain.Entity;

namespace Sale.Application.Services.Shops
{
    public class ShopService : IShopService
    {
        public async Task<Guid> CreateAsync(AddOrUpdateShopDTO dto, CancellationToken cancellationToken)
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

        public async Task<Guid> UpdateAsync(AddOrUpdateShopDTO dto, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
