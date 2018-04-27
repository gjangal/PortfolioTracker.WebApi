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
    }
}
