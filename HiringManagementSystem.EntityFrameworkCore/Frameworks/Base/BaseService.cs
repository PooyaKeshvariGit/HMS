using HiringManagementSystem.Domain.Contract.Interface;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HiringManagementSystem.EntityFrameworkCore.Frameworks.Base
{
    public class BaseService<E_Entity, D_DbContext, P_PrimaryKey> : IRepository<E_Entity, P_PrimaryKey>
        where E_Entity : class
        where D_DbContext : DbContext
    {
        #region [-Ctor-]

        public BaseService(D_DbContext context)
        {
            Context = context;
            DbSet = context.Set<E_Entity>();
        }

        #endregion

        #region [-Props-]

        public virtual DbSet<E_Entity> DbSet { get; set; }
        public virtual D_DbContext Context { get; set; }

        #endregion

        #region [-Tasks-]

        #region [-GetAllAsync()-]

        public virtual async Task<List<E_Entity>> GetAllAsync()
        {
            var query = await DbSet.AsNoTracking().ToListAsync();
            return query;
        }

        #endregion

        #region [-GetByIdAsync(P_PrimaryKey id)-]

        public virtual async Task<E_Entity> GetByIdAsync(P_PrimaryKey id)
        {
            var targetId = await DbSet.FindAsync(id);
            return targetId;
        }

        #endregion

        #region [-CreateAsync(E_Entity entity)-]

        public virtual async Task CreateAsync(E_Entity entity)
        {
            await DbSet.AddAsync(entity);
            await SaveChanges();
        }

        #endregion

        #region [-UpdateAsync(E_Entity entity)-]

        public virtual async Task UpdateAsync(E_Entity entity)
        {
            DbSet.Attach(entity);
            Context.Entry(entity).State = EntityState.Modified;
            await SaveChanges();
        }

        #endregion

        #region [-DeleteAsync(P_PrimaryKey id)-]

        public virtual async Task DeleteAsync(P_PrimaryKey id)
{
            var targetId =await DbSet.FindAsync(id);
            Context.Entry(targetId).State = EntityState.Deleted;
            await SaveChanges();
        }

        #endregion

        #region [-SaveChanges()-]

        public async Task SaveChanges()
        {
            await Context.SaveChangesAsync();
        }

        #endregion

        #endregion
    }
}
