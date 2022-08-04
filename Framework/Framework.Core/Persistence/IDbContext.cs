using System;
using System.Collections.Generic;
using System.Text;

namespace Framework.Core.Persistence
{
    public interface IDbContext : IDisposable
    {
        int SaveChanges();
        void Migrate();
        void ChangeDatabase(string connectionString);
        new void Dispose();
    }
}
