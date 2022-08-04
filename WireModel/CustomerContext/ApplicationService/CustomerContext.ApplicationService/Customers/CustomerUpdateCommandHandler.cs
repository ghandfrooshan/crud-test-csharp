using CustomerContext.Domain.Customers.Services;
using Framework.Core.Application;
using CustomerContext.ApplicationService.Contracts.Customers;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerContext.ApplicationService.Customers
{
    public class CustomerUpdateCommandHandler : ICommandHandler<CustomerUpdateCommand>
    {
        private readonly ICustomerRepository customerRepository;
  
        private readonly IPhoneNumberIsValidChecker phoneNumberIsValidChecker;
     

        public CustomerUpdateCommandHandler(
            ICustomerRepository customerRepository,
           
            IPhoneNumberIsValidChecker phoneNumberIsValidChecker
 


            )
        {
            this.customerRepository = customerRepository;
           
            this.phoneNumberIsValidChecker = phoneNumberIsValidChecker;

        }
        public void Execute(CustomerUpdateCommand command)
        {
            var customer = customerRepository.GetCustomerById(command.Id);

            customer.FirstName = command.FirstName;
            customer.LastName = command.LastName;
            customer.DateOfBirth = command.DateOfBirth;
                
           customer.SetPhoneNumber(command.PhoneNumber, phoneNumberIsValidChecker);
           
            customer.Email = command.Email;
            customer.SetBankAccountNumber(command.BankAccountNumber);
           


        }
    }
}
