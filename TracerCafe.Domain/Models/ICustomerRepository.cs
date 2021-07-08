using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace TracerCafe.Domain.Models
{
    public interface ICustomerRepository
    {
        /// <summary>
        /// Fetch a customer with the provided Id
        /// </summary>
        /// <param name="id">Customer id</param>
        /// <param name="cancellationToken"><see cref="CancellationToken"/> used to cancel the request</param>
        /// <returns><see cref="Customer"/> entity</returns>
        Task<Customer> FindByIdAsync(int id, CancellationToken cancellationToken = default);

        /// <summary>
        /// Fetch all the available customers
        /// Note: This should be paginated
        /// </summary>
        /// <returns>A collection of <see cref="Customer"/></returns>
        Task<IEnumerable<Customer>> GetAllAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Add a customer to the database
        /// </summary>
        /// <param name="customer"><see cref="Customer"/></param>
        /// <param name="cancellationToken"><see cref="CancellationToken"/> used to cancel the request</param>
        /// <returns><see cref="Customer"/> entity</returns>
        Task<Customer> AddAsync(Customer customer, CancellationToken cancellationToken = default);

        /// <summary>
        /// Update an existing customer with the provided values
        /// </summary>
        /// <param name="customer"><see cref="Customer"/></param>
        /// <param name="cancellationToken"><see cref="CancellationToken"/> used to cancel the request</param>
        /// <returns><see cref="Customer"/> entity</returns>
        Task<Customer> UpdateAsync(Customer customer, CancellationToken cancellationToken = default);

        /// <summary>
        /// Delete an existing customer from the database
        /// </summary>
        /// <param name="customer"><see cref="Customer"/></param>
        /// <param name="cancellationToken"><see cref="CancellationToken"/> used to cancel the request</param>
        /// <returns><see cref="Customer"/> entity</returns>
        Task<Customer> DeleteAsync(Customer customer, CancellationToken cancellationToken = default);
    }
}
