using Microsoft.EntityFrameworkCore;
using Sale.Application.Common.Interfaces;
using Sale.Application.DTO.Shops;
using Sale.Domain.Entity;

namespace Sale.Application.Services.Shops
{
    public class ShopService : IShopService
    {
        private readonly IApplicationDbContext _dbContext;

        public ShopService(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Guid> CreateAsync(AddOrUpdateShopDTO dto, CancellationToken cancellationToken)
        {
            var entity = new Shop
            {
                Id = Guid.NewGuid(),
                Name = dto.Name,
                Location = dto.Location
            };

            await _dbContext.Shops.AddAsync(entity, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }

        public async Task DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Shops.FirstOrDefaultAsync(x => x.Id.Equals(id), cancellationToken);

            _dbContext.Shops.Remove(entity);

            await _dbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task<IEnumerable<Shop>> GetAllAsync(CancellationToken cancellationToken)
            => await _dbContext.Shops.AsNoTracking().ToListAsync(cancellationToken);

        public async Task<IEnumerable<Shop>> SearchAsync(string param, CancellationToken cancellationToken)
        {
            var data = await _dbContext.Shops
                            .AsNoTracking()
                            .Where(c => c.Name.Contains(param) || c.Location.Contains(param))
                            .ToListAsync(cancellationToken);

            return data.OrderBy(x => x.Location).ToList();
        }

        public async Task<Guid> UpdateAsync(AddOrUpdateShopDTO dto, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Shops.FirstOrDefaultAsync(x => x.Id.Equals(dto.Id), cancellationToken);

            if (entity == null) return Guid.Empty;

            entity.Name = dto.Name;
            entity.Location = dto.Location;

            _dbContext.Shops.Update(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
}
