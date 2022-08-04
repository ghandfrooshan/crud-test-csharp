﻿using CustomerContext.Resources;
using Framework.Domain.Exception;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerContext.Domain.Customers.Exceptions
{
    public class EmailExistedAlreadyException:DomainException
    {
        public override string Message => ExceptionResources.EmailExistedAlreadyException;
    }
}
