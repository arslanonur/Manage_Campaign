using App.Engine;
using App.EntityFrameworkCore.Seed;

namespace App.EntityFrameworkCore
{
    public class EntityFrameworkCoreStartupTask : IStartupTask
    {
        public void Execute()
        {
            var dbContext = EngineContext.Current.Resolve<IDbContext>() as AppDbContext;

            SeedHelper.Seed(dbContext);
        }

        public int Order => 4;
    }
}
