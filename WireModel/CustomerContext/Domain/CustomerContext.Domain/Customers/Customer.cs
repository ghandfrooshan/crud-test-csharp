using CustomerContext.Domain.Customers.Exceptions;
using CustomerContext.Domain.Customers.Services;
using Framework.Core.Domain;
using Framework.Core.Persistence;
using Framework.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Text.RegularExpressions;

namespace CustomerContext.Domain.Customers
{
    public class Customer : EntityBase<Customer>, IAggregateRoot<Customer>
    {
        private readonly IEntityIdGenerator<Customer> entityIdGenerator;
        private readonly IPhoneNumberIsValidChecker phoneNumberIsValidChecker;
        //private readonly IBankNumberIsValidChecker bankNumberIsValidChecker;
        private readonly IEmailIsValidChecker emailIsValidChecker;
        private readonly IEmailIsUniqueChecker emailIsUniqueChecker;
        private readonly ICustomerIsUniqueChecker customerIsUniqueChecker;

        public Customer()
        {

        }
        public Customer(
            IEntityIdGenerator<Customer> entityIdGenerator,
            IPhoneNumberIsValidChecker phoneNumberIsValidChecker,
            //IBankNumberIsValidChecker bankNumberIsValidChecker,
            IEmailIsValidChecker emailIsValidChecker,

            IEmailIsUniqueChecker emailIsUniqueChecker,
            ICustomerIsUniqueChecker customerIsUniqueChecker,

            string firstName, string lastName, DateTime dateOfBirth, string phoneNumber, string email, string bankAccountNumber) : base(entityIdGenerator)
        {
            this.entityIdGenerator = entityIdGenerator;
            this.phoneNumberIsValidChecker = phoneNumberIsValidChecker;
            //this.bankNumberIsValidChecker = bankNumberIsValidChecker;
            this.emailIsValidChecker = emailIsValidChecker;
            this.emailIsUniqueChecker = emailIsUniqueChecker;
            this.customerIsUniqueChecker = customerIsUniqueChecker;
            SetCustomer(firstName, lastName, dateOfBirth, customerIsUniqueChecker);
            SetEmail(email, emailIsValidChecker, emailIsUniqueChecker);
            SetPhoneNumber(phoneNumber, phoneNumberIsValidChecker);
            SetBankAccountNumber(bankAccountNumber);
            SetId();


        }

        public void SetCustomer(string firstName, string lastName, DateTime dateOfBirth, ICustomerIsUniqueChecker customerIsUniqueChecker)
        {
            CheckFirstName(firstName);
            CheckLastName(lastName);
            CheckDateOfBirth(dateOfBirth);
            if ( customerIsUniqueChecker.IsAlreadyExist(firstName,lastName,dateOfBirth))
                throw new CustomerExistedAlreadyException();
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;

                
            


        }
        public void SetEmail(string email, IEmailIsValidChecker emailIsValidChecker, IEmailIsUniqueChecker emailIsUniqueChecker)
        {
            if (string.IsNullOrWhiteSpace(email))
                throw new FieldIsRequiredException();


            
            if(!emailIsValidChecker.IsValid(email))

                throw new EmailFormatIsNotValidException();


            if (emailIsUniqueChecker.IsAlreadyExist(email))
                throw new EmailExistedAlreadyException();

                Email = email;
            
        }
        public void SetPhoneNumber(string phoneNumber, IPhoneNumberIsValidChecker phoneNumberIsValidChecker)
        {
           if( !phoneNumberIsValidChecker.Isvalid(phoneNumber))
            throw new PhoneNumberIsNotValidException();
            PhoneNumber = phoneNumber;
                 
        }
        public void SetBankAccountNumber(string bankAccountNumber)
        {
            if (bankAccountNumber.All(c => !char.IsDigit(c)))
                throw new BankAccountNumberIsNotValidException();
            BankAccountNumber = bankAccountNumber;
        }

        private void CheckFirstName(string firstName)
        {

            if (string.IsNullOrWhiteSpace(firstName))
                throw new FieldIsRequiredException();
        }
        private void CheckLastName(string lastName)
        {

            if (string.IsNullOrWhiteSpace(lastName))
                throw new FieldIsRequiredException();

        }
        private void CheckDateOfBirth(DateTime dateOfBirth)
        {

            if (string.IsNullOrWhiteSpace( dateOfBirth.ToString()))
                throw new FieldIsRequiredException();
           
        }

        public IEnumerable<Expression<Func<Customer, object>>> GetAggregateExpressions()
        {
            yield return null;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string BankAccountNumber { get; set; }


    }
}


