using CustomerContext.Domain.Customers;
using CustomerContext.Domain.Customers.Exceptions;
using CustomerContext.Domain.Customers.Services;
using CustomerContext.Domain.Services.Customers;
using Framework.Core.Persistence;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerContext.Domain.Test.Customers
{

    namespace CustomerContext.Domain.Test.Customers
    {
        [TestClass]
        public class CustomerTest
        {


            private Mock<IEntityIdGenerator<Customer>> idGeneratorMock;
            private PhoneNumberIsValidChecker phoneNumberIsValidChecker;
            private EmailIsValidChecker emailIsValidChecker;
            private Mock<IEmailIsUniqueChecker> emailIsUniqueCheckerMock;
            private Mock<ICustomerIsUniqueChecker> customerIsUniqueCheckerMock;

            private string email = "test@gmail.com";
            private string firstName = "Zohreh";
            private string lastName = "Ghandfrooshan";
            private DateTime dateOfBirth = new DateTime(1988, 01, 01);
            private string phoneNum = "+989364306439";
            private string accountNum = "+989364306439";


            [TestInitialize]
            public void SetUp()
            {
                idGeneratorMock = new Mock<IEntityIdGenerator<Customer>>();
                idGeneratorMock.Setup(o => o.GetNewId()).Returns(1);

                phoneNumberIsValidChecker = new PhoneNumberIsValidChecker();
                emailIsValidChecker = new EmailIsValidChecker();
                emailIsUniqueCheckerMock = new Mock<IEmailIsUniqueChecker>();
                customerIsUniqueCheckerMock = new Mock<ICustomerIsUniqueChecker>();

            }


            [TestMethod]
            [DataRow("Test")]
            [DataRow("Test.com")]
            [DataRow("@Test.com")]
            [DataRow("Test.com@")]

           // [ExpectedException(typeof(EmailFormatIsNotValidException))]
            public void SetEmail_Validation_RerurnFalse(string input)
            {
                var isValid = emailIsValidChecker.IsValid(input);
                Assert.IsFalse(isValid);
            }


            [TestMethod]
            [DataRow("+123456")]
            [DataRow("12345")]
           
            [DataRow("12.358")]
            [DataRow("123")]

            //[ExpectedException(typeof(PhoneNumberIsNotValidException))]
            public void SetPhoneNumber_Validation_RerurnFalse(string input)
            {
                var isValid = phoneNumberIsValidChecker.Isvalid(input);
                Assert.IsFalse(isValid);
            }

            private void GivenEmailIsAlreadyExist(string email)
            {
                emailIsUniqueCheckerMock.Setup(z => z.IsAlreadyExist(email)).Throws<EmailExistedAlreadyException>();
            }
            private void GivenCustomerIsAlreadyExist(string firstName, string lastNname, DateTime dateOfBitth)
            {
                customerIsUniqueCheckerMock.Setup(z => z.IsAlreadyExist(firstName, lastNname, dateOfBitth)).Throws<CustomerExistedAlreadyException>();
            }



            [TestMethod]
            [ExpectedException(typeof(EmailExistedAlreadyException))]
            public void SetEmail_Validation_DuplicatedException()
            {
                string DuplicatedEmail = "test@gmail.com";
                GivenEmailIsAlreadyExist(email);

                CreateCustomer(firstName, lastName, dateOfBirth, phoneNum, DuplicatedEmail, accountNum);
            }

            [TestMethod]
            [ExpectedException(typeof(CustomerExistedAlreadyException))]
            public void SetCustomer_Validation_DuplicatedException()
            {
                string duplicatedFirstName = "Zohreh";
                string duplicatedlastName = "Ghandfrooshan";
                DateTime duplicatedDateOfBirth = new DateTime(1988, 01, 01); ;
                GivenCustomerIsAlreadyExist(duplicatedFirstName, duplicatedlastName, duplicatedDateOfBirth);

                CreateCustomer(duplicatedFirstName, duplicatedlastName, duplicatedDateOfBirth, phoneNum, email, accountNum);
            }


            private Customer CreateCustomer(

                string firstName, string lastName, DateTime dateOfBirth, string phoneNumber, string email, string bankAccountNumber)



            {
                //if (iban != null)
                //{
                //    validatorMock.Setup(z => z.IsIbanValid(iban.Trim().ToUpper())).Returns(true);
                //    validatorMock.Setup(z => z.IsIbanValid(iban)).Returns(true);
                //}

                return new Customer(idGeneratorMock.Object, phoneNumberIsValidChecker, emailIsValidChecker, emailIsUniqueCheckerMock.Object, customerIsUniqueCheckerMock.Object,
                 firstName, lastName, dateOfBirth, phoneNumber, email, bankAccountNumber);
            }





        }
    }
}
