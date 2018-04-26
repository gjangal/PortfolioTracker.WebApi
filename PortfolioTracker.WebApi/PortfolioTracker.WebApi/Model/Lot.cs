using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortfolioTracker.WebApi.Model
{
    public class Lot
    {
        public int Id { get; set; }
        public string Ric { get; set; }
        public float Price { get; set; }
        public float Qty { get; set; }
        public DateTime Date { get; set; }
        public float Commission { get; set; }
    }
}
