using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortfolioTracker.WebApi.Model
{
    public class Portfolio
    {
        public int Id                      { get; set; }
        public string Name                 { get; set; }
        public IEnumerable<Lot> Holdings   { get; private set; }
        public float Cash                  { get; private set; }    
    }
}
