using Sale.Application.DTO.Shops;
using Sale.Domain.Entity;

namespace Sale.Application.Services.Shops
{
    public interface IShopService
    {
        Task<IEnumerable<Shop>> GetAllAsync(CancellationToken cancellationToken);
        Task<Guid> CreateAsync(AddOrUpdateShopDTO dto, CancellationToken cancellationToken);
        Task<Guid> UpdateAsync(AddOrUpdateShopDTO dto, CancellationToken cancellationToken);
        Task DeleteAsync(Guid id, CancellationToken cancellationToken);
        Task<IEnumerable<Shop>> SearchAsync(string @param, CancellationToken cancellationToken);
    }
}
