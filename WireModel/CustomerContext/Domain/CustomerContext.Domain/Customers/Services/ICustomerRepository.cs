using Framework.Core.Persistence;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace CustomerContext.Domain.Customers.Services
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        bool Contain(Expression<Func<Customer, bool>> expression);
        void CreateCustomer(Customer customer);
        Customer GetCustomerById(long CusomerId);
        void DeleteCustomer(long CusomerId);

    }
}
