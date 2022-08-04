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
        private readonly IEmailIsValidChecker emailIsValidChecker;
        private readonly IEmailIsUniqueChecker emailIsUniqueChecker;
        private readonly ICustomerIsUniqueChecker customerIsUniqueChecker;

        public CustomerUpdateCommandHandler(
            ICustomerRepository customerRepository,
           
            IPhoneNumberIsValidChecker phoneNumberIsValidChecker,
            IEmailIsValidChecker emailIsValidChecker,
            IEmailIsUniqueChecker emailIsUniqueChecker,
            ICustomerIsUniqueChecker customerIsUniqueChecker


            )
        {
            this.customerRepository = customerRepository;
           
            this.phoneNumberIsValidChecker = phoneNumberIsValidChecker;
            this.emailIsValidChecker = emailIsValidChecker;
            this.emailIsUniqueChecker = emailIsUniqueChecker;
            this.customerIsUniqueChecker = customerIsUniqueChecker;
        }
        public void Execute(CustomerUpdateCommand command)
        {
            var customer = customerRepository.GetCustomerById(command.Id);

            //customer.SetCustomer(command.FirstName, command.LastName, command.DateOfBirth, customerIsUniqueChecker);
            customer.FirstName = command.FirstName;
            customer.LastName = command.LastName;
            customer.DateOfBirth = command.DateOfBirth;
                
           // customer.SetCustomer(command.FirstName, command.LastName, command.DateOfBirth, customerIsUniqueChecker);
            customer.SetPhoneNumber(command.PhoneNumber, phoneNumberIsValidChecker);
            // customer.SetEmail(command.Email, emailIsValidChecker, emailIsUniqueChecker);
            customer.Email = command.Email;
            customer.SetBankAccountNumber(command.BankAccountNumber);
           


        }
    }
}
