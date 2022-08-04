using System;
using System.Collections.Generic;
using System.Text;

namespace Framework.Domain.Exception
{
    public class DomainException : ApplicationException
    {
        public DomainException()
        {
        }


        public DomainException(string message) : base(message)
        {
        }
    }
}
