using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TracerCafe.Domain.Models;

namespace TracerCafe.Infrastructure.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly CustomerContext _context;

        public CustomerRepository(CustomerContext context)
        {
            _context = context;
        }

        /// <inheritdoc />
        public async Task<Customer> FindByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            var customer = await _context
                .Customer
                .FindAsync(id)
                .ConfigureAwait(false);

            return customer;
        }

        /// <inheritdoc />
        public async Task<IEnumerable<Customer>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            var customers = await _context
                .Customer
                .ToArrayAsync(cancellationToken)
                .ConfigureAwait(false);

            return customers;
        }

        /// <inheritdoc />
        public async Task<Customer> AddAsync(Customer customer, CancellationToken cancellationToken = default)
        {
            var result = await _context
                .Customer
                .AddAsync(customer, cancellationToken)
                .ConfigureAwait(false);

            await _context.SaveChangesAsync(cancellationToken);

            return result.Entity;
        }

        /// <inheritdoc />
        public async Task<Customer> UpdateAsync(Customer customer, CancellationToken cancellationToken = default)
        {
            var entity = await _context
                .Customer
                .FirstOrDefaultAsync(x => x.Id == customer.Id, cancellationToken)
                .ConfigureAwait(false);

            entity.Title = customer.Title;
            entity.Surname = customer.Surname;
            entity.Address1 = customer.Address1;
            entity.Address2 = customer.Address2;
            entity.Address3 = customer.Address3;
            entity.Address4 = customer.Address4;
            entity.Age = customer.Age;
            entity.PostCode = customer.PostCode;
            entity.Telephone = customer.Telephone;

            await _context.SaveChangesAsync(cancellationToken);

            return customer;
        }

        /// <inheritdoc />
        public async Task<Customer> DeleteAsync(Customer customer, CancellationToken cancellationToken = default)
        {
            var entity = await _context.Customer.FirstOrDefaultAsync(x => x.Id == customer.Id, cancellationToken);

            _context.Customer.Remove(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return entity;
        }
    }
}
