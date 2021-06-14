using System.Linq;

namespace DAL.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        IQueryable<TEntity> FindAll();
        void Delete(TEntity entity);
        
    }
}
