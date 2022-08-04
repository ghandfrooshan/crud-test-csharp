using Framework.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerContext.Domain.Customers.Services
{
    public interface ICustomerIsUniqueChecker:IDomainService
    {
        bool IsAlreadyExist(string firstName, string lastName, DateTime dateOfBirth);
    }
}
