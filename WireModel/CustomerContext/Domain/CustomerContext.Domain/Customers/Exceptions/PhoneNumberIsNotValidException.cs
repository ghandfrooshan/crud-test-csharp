using CustomerContext.Resources;
using Framework.Domain.Exception;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerContext.Domain.Customers.Exceptions
{
   public class PhoneNumberIsNotValidException :DomainException
    {
        public override string Message => ExceptionResources.PhoneNumberIsNotValidException;
    }
}
