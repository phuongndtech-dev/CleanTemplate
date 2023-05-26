using Microsoft.EntityFrameworkCore;
using Sale.Application.Common.Interfaces;
using Sale.Application.DTO.Customers;
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

        public async Task<Guid> CreateAsync(AddOrUpdateCustomerDTO customer, CancellationToken cancellationToken)
        {
            var entity = new Customer
            {
                Id = Guid.NewGuid(),
                Name = customer.Name,
                DOB = customer.DOB,
                Email = customer.Email
            };

            await _dbContext.Customers.AddAsync(entity, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return customer.Id;
        }

        public async Task DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Customers.FirstOrDefaultAsync(x => x.Id.Equals(id), cancellationToken);

            _dbContext.Customers.Remove(entity);
        }

        public async Task<IEnumerable<Customer>> GetAllAsync(CancellationToken cancellationToken)
            => await _dbContext.Customers.AsNoTracking().ToListAsync(cancellationToken);

        public async Task<IQueryable<Customer>> SearchAsync(string param, CancellationToken cancellationToken)
        {
            return _dbContext.Customers.Where(c => c.Name.Contains(param) || c.Email.Contains(param));
        }

        public async Task<Guid> UpdateAsync(Customer customer, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Customers.FirstOrDefaultAsync(x => x.Id.Equals(customer.Id), cancellationToken);

            if (entity == null) return Guid.Empty;

            entity.Name = customer.Name;
            entity.DOB = customer.DOB;
            entity.Email = customer.Email;

            _dbContext.Customers.Update(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
}
