using Microsoft.EntityFrameworkCore;
using Sale.Application.Common;
using Sale.Application.Common.Interfaces;
using Sale.Application.DTO.Customers;
using Sale.Application.Exception.Customers;
using Sale.Domain.Entity;

namespace Sale.Application.Services.Customers
{
    public class CustomerService : ICustomerService
    {
        private readonly IApplicationDbContext _dbContext;

        public CustomerService(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Guid> CreateAsync(AddOrUpdateCustomerDTO dto, CancellationToken cancellationToken)
        {
            var entity = new Customer
            {
                Id = Guid.NewGuid(),
                Name = dto.Name,
                DOB = dto.DOB,
                Email = dto.Email
            };

            await _dbContext.Customers.AddAsync(entity, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }

        public async Task DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Customers.FirstOrDefaultAsync(x => x.Id.Equals(id), cancellationToken)
                ?? throw new CustomerCustomException(ApplicationConst.CustomerNotFound);

            _dbContext.Customers.Remove(entity);

            await _dbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task<IEnumerable<Customer>> GetAllAsync(CancellationToken cancellationToken)
            => await _dbContext.Customers.AsNoTracking().ToListAsync(cancellationToken);

        public async Task<IEnumerable<Customer>> SearchAsync(string param, CancellationToken cancellationToken)
        {
            var data = await _dbContext.Customers
                        .AsNoTracking()
                        .Where(c => c.Name.Contains(param) || c.Email.Contains(param))
                        .ToListAsync(cancellationToken);

            return data.OrderBy(x => x.Email).ToList();
        }

        public async Task<Guid> UpdateAsync(AddOrUpdateCustomerDTO dto, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Customers.FirstOrDefaultAsync(x => x.Id.Equals(dto.Id), cancellationToken);

            if (entity == null) return Guid.Empty;

            entity.Name = dto.Name;
            entity.DOB = dto.DOB;
            entity.Email = dto.Email;

            _dbContext.Customers.Update(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
}
