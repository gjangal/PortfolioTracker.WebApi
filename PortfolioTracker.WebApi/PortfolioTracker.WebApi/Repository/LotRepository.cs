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
            using (var connection = new SqlConnection(Configuration.GetValue<string>("ConnectionStrings:MarketData")))
            {
                connection.Open();
                var sql = $"DELETE FROM dbo.Lot where Id=@lotId";
                int rows =  connection.Execute(sql, new { lotId });

                if(rows > 0)
                {
                    return true;
                }

                return false;
            }
        }

        public Lot GetSingle(int lotId)
        {
            using (var connection = new SqlConnection(Configuration.GetValue<string>("ConnectionStrings:MarketData")))
            {
                connection.Open();
                var sql = $"select Id, Ric, Price, Qty , Date, Commission, Side, PortfolioId from dbo.Lot where Id={lotId}";
                return connection.Query<Lot>(sql).FirstOrDefault();
            }

        }

        public IEnumerable<Lot> GetList()
        {
            using (var connection = new SqlConnection(Configuration.GetValue<string>("ConnectionStrings:MarketData")))
            {
                connection.Open();
                var sql = $"select Id, Ric, Price, Qty , Date, Commission, Side, PortfolioId from dbo.Lot";
                return connection.Query<Lot>(sql);
            }
        }

        public bool Insert(Lot lot)
        {
            using (var connection = new SqlConnection(Configuration.GetValue<string>("ConnectionStrings:MarketData")))
            {
                connection.Open();
                var sql = $"INSERT [dbo].[Lot] ([Id], [Ric],[Price],[Qty],[Date],[Commission],[Side],[PortfolioId]) VALUES (@Id, @Ric,@Price,@Qty, @Date, @Commission, @Side, @PortfolioId)";
                int rows = connection.Execute(sql,new { lot.Id, lot.Ric, lot.Price, lot.Qty, lot.Date, lot.Commission, lot.Side, lot.PortfolioId});

                if(rows > 0)
                {
                    return true;
                }

                return false;
            }

        }

        public bool Update(Lot lot)
        {
            using (var connection = new SqlConnection(Configuration.GetValue<string>("ConnectionStrings:MarketData")))
            {
                connection.Open();
                var sql = $"UPDATE [dbo].[Lot] SET [Id]=@Id, [Ric] = @Ric ,[Price] = @Price ,[Qty] = @Qty, [Date]=@Date, [Commission]=@Commission,[Side]=@Side,[PortfolioId]=@PortfolioId WHERE Id={lot.Id}";
                int rows = connection.Execute(sql, new {lot.Id, lot.Ric, lot.Price, lot.Qty, lot.Date, lot.Commission, lot.Side, lot.PortfolioId });

                if (rows > 0)
                {
                    return true;
                }

                return false;
            }
        }
    }
}
