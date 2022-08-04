using Framework.Core.Persistence;
using Microsoft.EntityFrameworkCore;


namespace Framework.Persistence
{
   public class DbContextBase : DbContext, IDbContext
    {
        public DbContextBase(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
            Database.SetCommandTimeout(60);
        }


        public override int SaveChanges()
        {
            return base.SaveChanges();
        }


        public void Migrate()
        {
            base.Database.Migrate();
        }


        public void ChangeDatabase(string connectionString)
        {
            base.Database.GetDbConnection().ConnectionString = connectionString;
        }


        public override void Dispose()
        {
            base.Dispose();
        }
    }
}
