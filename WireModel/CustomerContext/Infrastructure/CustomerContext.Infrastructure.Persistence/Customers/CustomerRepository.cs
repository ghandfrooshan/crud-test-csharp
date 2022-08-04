using CustomerContext.Domain.Customers;
using CustomerContext.Domain.Customers.Services;
using Framework.Core.DependencyInjection;
using Framework.Core.Persistence;
using Framework.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace CustomerContext.Infrastructure.Persistence.Customers
{
    public class CustomerRepository : RepositoryBase<Customer>, ICustomerRepository
    {
        private readonly IDiContainer container;
        public CustomerRepository(IDbContext dbContext, IDiContainer container) : base(dbContext)
        {
            this.container = container;
        }

        public Customer GetCustomerById(long id)
        {
            return DbContext.Set<Customer>().Single(x => x.Id == id);
        }

        bool ICustomerRepository.Contain(Expression<Func<Customer, bool>> expression)
        {
            return DbContext.Set<Customer>().Any(expression);
        }

        void ICustomerRepository.CreateCustomer(Customer customer)
        {
            DbContext.Set<Customer>().Add(customer);
        }

        void ICustomerRepository.DeleteCustomer(long CusomerId)
        {
            var customer = DbContext.Set<Customer>().Single(a => a.Id == CusomerId);
            DbContext.Set<Customer>().Remove(customer);
        }

        Customer ICustomerRepository.GetCustomerById(long CusomerId)
        {
            return DbContext.Set<Customer>()
              
                .Single(o => o.Id == CusomerId);
        }
    }
}
