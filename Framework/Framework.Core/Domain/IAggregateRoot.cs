using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Framework.Core.Domain
{
    public interface IAggregateRoot<TAggregateRoot> where TAggregateRoot : class, IEntityBase
    {
        IEnumerable<Expression<Func<TAggregateRoot, object>>> GetAggregateExpressions();
    }
}
