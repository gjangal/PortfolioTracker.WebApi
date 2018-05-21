using PortfolioTracker.WebApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortfolioTracker.WebApi.Repository
{
    public interface ILotRepository:IRepository<Lot>
    {
    }

    public interface IRepository<TEntity>
        where TEntity:class, IDbEntity
    {
        IEnumerable<TEntity> GetList();
        TEntity GetSingle(int Id);
        bool Insert(TEntity lot);
        bool Delete(int Id);
        bool Update(TEntity lot);
        Task<IEnumerable<TEntity>> GetListAsync();
        Task<TEntity> GetSingleAsync(int Id);
        Task<bool> InsertAsync(TEntity lot);
        Task<bool> DeleteAsync(int Id);
        Task<bool> UpdateAysnc(TEntity lot);
    }
}
