using Framework.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerContext.Domain.Customers.Services
{
    public interface IEmailIsUniqueChecker :IDomainService
    {
        bool IsAlreadyExist(string email);
    }
    
}
