using System;
using System.Collections.Generic;
using System.Text;

namespace Framework.Core.Persistence
{
  public  interface IUnitOfWork
    {
        void Commit();

        void Rollback();
    }
}
