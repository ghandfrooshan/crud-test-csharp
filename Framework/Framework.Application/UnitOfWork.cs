using Framework.Core.Persistence;
using System;
using System.Collections.Generic;
using System.Text;

namespace Framework.Application
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDbContext dbContext;


        public UnitOfWork(IDbContext dbContext)
        {
            this.dbContext = dbContext;
        }


        public void Commit()
        {
            dbContext.SaveChanges();
        }


        public void Rollback()
        {
            dbContext.Dispose();
        }
    }
}
