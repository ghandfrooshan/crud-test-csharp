using CustomerContext.ApplicationService.Contracts.Customers;
using CustomerContext.Domain.Customers;
using CustomerContext.Domain.Customers.Services;
using Framework.Core.Application;
using Framework.Core.Persistence;

using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerContext.ApplicationService.Customers
{
    public class CustomerCreateCommandHandler : ICommandHandler<CustomerCreateCommand>
    {
        private readonly ICustomerRepository customerRepository;
        private readonly IEntityIdGenerator<Customer> entityIdGenerator;
        private readonly IPhoneNumberIsValidChecker phoneNumberIsValidChecker;
        private readonly IEmailIsValidChecker emailIsValidChecker;
        private readonly IEmailIsUniqueChecker emailIsUniqueChecker;
        private readonly ICustomerIsUniqueChecker customerIsUniqueChecker;

        public CustomerCreateCommandHandler(
            ICustomerRepository customerRepository,
            IEntityIdGenerator<Customer> entityIdGenerator,
            IPhoneNumberIsValidChecker phoneNumberIsValidChecker,
            IEmailIsValidChecker emailIsValidChecker,
            IEmailIsUniqueChecker emailIsUniqueChecker,
            ICustomerIsUniqueChecker customerIsUniqueChecker


            )
        {
            this.customerRepository = customerRepository;
            this.entityIdGenerator = entityIdGenerator;
            this.phoneNumberIsValidChecker = phoneNumberIsValidChecker;
            this.emailIsValidChecker = emailIsValidChecker;
            this.emailIsUniqueChecker = emailIsUniqueChecker;
            this.customerIsUniqueChecker = customerIsUniqueChecker;
        }
        public void Execute(CustomerCreateCommand command)
        {
            var customer = new Customer(entityIdGenerator, phoneNumberIsValidChecker, emailIsValidChecker, emailIsUniqueChecker, customerIsUniqueChecker, command.FirstName, command.LastName, command.DateOfBirth, command.PhoneNumber, command.Email, command.BankAccountNumber);

            customerRepository.CreateCustomer(customer);
        }
    }
}
