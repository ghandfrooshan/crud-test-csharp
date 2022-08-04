using System;
using System.Collections.Generic;
using System.Text;

namespace Framework.Core.Persistence
{
    public interface IEntityIdGenerator<TEntity> where TEntity : class
    {
        long GetNewId();
    }
}
