using Abp.Domain.Entities;
using Abp.EntityFramework;
using Abp.EntityFramework.Repositories;

namespace OutlookFW.EntityFramework.Repositories
{
    public abstract class OutlookFWRepositoryBase<TEntity, TPrimaryKey> : EfRepositoryBase<OutlookFWDbContext, TEntity, TPrimaryKey>
        where TEntity : class, IEntity<TPrimaryKey>
    {
        protected OutlookFWRepositoryBase(IDbContextProvider<OutlookFWDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        //add common methods for all repositories
    }

    public abstract class OutlookFWRepositoryBase<TEntity> : OutlookFWRepositoryBase<TEntity, int>
        where TEntity : class, IEntity<int>
    {
        protected OutlookFWRepositoryBase(IDbContextProvider<OutlookFWDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        //do not add any method here, add to the class above (since this inherits it)
    }
}
