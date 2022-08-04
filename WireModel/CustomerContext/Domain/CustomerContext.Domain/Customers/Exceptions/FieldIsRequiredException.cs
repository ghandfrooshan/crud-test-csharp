using CustomerContext.Resources;
using Framework.Domain.Exception;


namespace CustomerContext.Domain.Customers.Exceptions
{
    public class FieldIsRequiredException : DomainException
    {
        public override string Message => ExceptionResources.FieldIsRequiredException;

    }
}
