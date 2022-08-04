using CustomerContext.Domain.Customers.Services;
using Framework.Core.Application;
using CustomerContext.ApplicationService.Contracts.Customers;
using System;
using System.Collections.Generic;
using System.Text;


namespace CustomerContext.ApplicationService.Customers
{
    public class CustomerDeleteCommandHandler : ICommandHandler<CustomerDeleteCommand>
    {
        private readonly ICustomerRepository customerRepository;

        public CustomerDeleteCommandHandler(ICustomerRepository customerRepository)
        {
            this.customerRepository = customerRepository;
        }
        public void Execute(CustomerDeleteCommand command)
        {

            customerRepository.DeleteCustomer(command.Id);
        }
    }
}
