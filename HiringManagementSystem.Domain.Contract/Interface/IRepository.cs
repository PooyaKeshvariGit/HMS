using System.Collections.Generic;
using System.Threading.Tasks;

namespace HiringManagementSystem.Domain.Contract.Interface
{
    public interface IRepository<E_Entity, P_PrimaryKey> 
        where E_Entity : class
    {
        Task<List<E_Entity>> GetAllAsync();
        Task<E_Entity> GetByIdAsync(P_PrimaryKey id);
        Task CreateAsync(E_Entity entity);
        Task UpdateAsync(E_Entity entity);
        Task DeleteAsync(P_PrimaryKey id);
        Task SaveChanges();
    }
}
