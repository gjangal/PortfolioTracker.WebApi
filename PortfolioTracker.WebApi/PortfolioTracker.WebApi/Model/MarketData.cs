using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortfolioTracker.WebApi.Model
{
    public class MarketData
    {
        public int Id { get; set; }
        public string Ric { get; set; }
        public float MktPrice { get; set; }
        public float LastPx { get; set; }
        public DateTime Date { get; set; }
    }
}
