using PortfolioTracker.WebApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortfolioTracker.WebApi.Repository
{
    public interface ILotRepository
    {
        IEnumerable<Lot> GetLots();
        Lot GetLotById(int lotId);
        bool InsertLot(Lot lot);
        bool DeleteLot(int lotId);
        bool UpdateLot(Lot lot);
    }
}
