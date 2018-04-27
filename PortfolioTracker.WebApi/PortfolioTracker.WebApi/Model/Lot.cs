using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortfolioTracker.WebApi.Model
{
    public class Lot: ILot
    {
        public int       Id            { get; set; }
        public int       PortfolioId   { get; set; }
        public string    Ric           { get; set; }
        public float     Price         { get; set; }
        public float     Qty           { get; set; }
        public DateTime  Date          { get; set; }
        public float     Commission    { get; set; }
        public string    Side          { get; set; }
    }

    public interface IDbEntity
    {
        int Id { get; set; }
    }

    public interface ILot : IDbEntity
    {
        int PortfolioId { get; set; }
        string Ric { get; set; }
        float Price { get; set; }
        float Qty { get; set; }
        DateTime Date { get; set; }
        float Commission { get; set; }
        string Side { get; set; }
    }

}
