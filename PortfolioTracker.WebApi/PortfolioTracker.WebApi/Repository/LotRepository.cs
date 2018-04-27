using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using PortfolioTracker.WebApi.Model;
using Dapper;
using System.Data;
using Microsoft.Extensions.Configuration;

namespace PortfolioTracker.WebApi.Repository
{
    public class LotRepository : ILotRepository
    {
        public LotRepository(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public bool Delete(int lotId)
        {
            throw new NotImplementedException();
        }

        public Lot GetSingle(int lotId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Lot> GetList()
        {
            using (var connection = new SqlConnection(Configuration.GetValue<string>("ConnectionStrings:MarketData")))
            {
                connection.Open();
                var sql = $"select Id, Ric, Price, Qty , Date, Commission from dbo.Lot";
                return connection.Query<Lot>(sql);
            }
        }

        public bool Insert(Lot lot)
        {
            throw new NotImplementedException();
        }

        public bool Update(Lot lot)
        {
            throw new NotImplementedException();
        }
    }
}
