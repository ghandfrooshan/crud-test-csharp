

using CustomerContext.ApplicationService.Contracts.Customers;
using System;

namespace CustomerContext.Facade.Contracts
{
    public interface ICustomerCommandFacade
    {
        void CreateCustomer(CustomerCreateCommand command);
        void UpdateCustomer(CustomerUpdateCommand command);
        void DeleteCustomer(CustomerDeleteCommand command);

    }
}
