using Framework.Domain.Exception;
using CustomerContext.Resources;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerContext.Domain.Customers.Exceptions
{
    public class BankAccountNumberIsNotValidException : DomainException
    {
        public override string Message => ExceptionResources.BankAccountNumberIsNotValidException;

    }
}
