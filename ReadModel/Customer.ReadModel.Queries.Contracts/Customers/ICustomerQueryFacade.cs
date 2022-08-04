using CustomerContext.ReadModel.Queries.Contracts.Customers.DataContracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerContext.ReadModel.Queries.Contracts.Customers
{
    public interface  ICustomerQueryFacade
    {
        IList<CustomerDto> GetCustomers();
        CustomerDto GetCustomerById(long id);
    }
}
