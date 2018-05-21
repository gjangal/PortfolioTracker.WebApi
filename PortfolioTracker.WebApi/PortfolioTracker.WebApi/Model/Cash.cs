using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortfolioTracker.WebApi.Model
{
    public interface ICash : IDbEntity
    {
        DateTime Date { get; }
        int PortfolioId { get; }
        float Amount { get; }
    }

    public class Cash : ICash
    {
        public DateTime Date { get; set; }

        public int PortfolioId { get; set; }

        public float Amount { get; set; }

        public int Id { get; set; }
    }
}
