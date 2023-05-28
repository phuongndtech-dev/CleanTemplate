using Microsoft.EntityFrameworkCore;
using Sale.Application.Common.Interfaces;
using Sale.Application.DTO.Products;
using Sale.Domain.Entity;

namespace Sale.Application.Services.Products
{
    public class ProductService : IProductService
    {
        private readonly IApplicationDbContext _dbContext;

        public ProductService(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Guid> CreateAsync(AddOrUpdateProductDTO dto, CancellationToken cancellationToken)
        {
            var entity = new Product
            {
                Id = Guid.NewGuid(),
                Name = dto.Name,
                Price = dto.Price
            };

            await _dbContext.Products.AddAsync(entity, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }

        public async Task DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Products.FirstOrDefaultAsync(x => x.Id.Equals(id), cancellationToken);

            _dbContext.Products.Remove(entity);

            await _dbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task<IEnumerable<Product>> GetAllAsync(CancellationToken cancellationToken)
            => await _dbContext.Products.AsNoTracking().ToListAsync(cancellationToken);

        public async Task<IQueryable<Product>> SearchAsync(string param, CancellationToken cancellationToken)
            => _dbContext.Products.AsNoTracking().Where(c => c.Name.Contains(param));

        public async Task<Guid> UpdateAsync(AddOrUpdateProductDTO dto, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Products.FirstOrDefaultAsync(x => x.Id.Equals(dto.Id), cancellationToken);

            if (entity == null) return Guid.Empty;

            entity.Name = dto.Name;
            entity.Price = dto.Price;

            _dbContext.Products.Update(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
}
