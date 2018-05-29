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

        public async Task<IEnumerable<Lot>> GetListAsync()
        {
            using (var connection = new SqlConnection(Configuration.GetValue<string>("ConnectionStrings:MarketData")))
            {
                connection.Open();
                var sql = $"select Id, Ric, Price, Qty , Date, Commission, Side, PortfolioId from dbo.Lot";
                return await connection.QueryAsync<Lot>(sql);
            }
        }

        public async Task<Lot> GetSingleAsync(int Id)
        {
            using (var connection = new SqlConnection(Configuration.GetValue<string>("ConnectionStrings:MarketData")))
            {
                connection.Open();
                var sql = $"select Id, Ric, Price, Qty , Date, Commission, Side, PortfolioId from dbo.Lot where Id={Id}";
                return (await connection.QueryAsync<Lot>(sql)).FirstOrDefault();
            }

        }

        public async Task<bool> InsertAsync(Lot lot)
        {
            using (var connection = new SqlConnection(Configuration.GetValue<string>("ConnectionStrings:MarketData")))
            {
                connection.Open();

                var existsSql = $"SELECT TOP 1 Id from [dbo].[Lot] where Id={lot.Id}";

                var exists = await connection.QueryAsync<Lot>(existsSql);


                if (exists.Any())
                {
                     return await UpdateAysnc(lot);
                }

                var sql = $"INSERT [dbo].[Lot] ([Ric],[Price],[Qty],[Date],[Commission],[Side],[PortfolioId]) VALUES ( @Ric,@Price,@Qty, @Date, @Commission, @Side, @PortfolioId)";
                int rows = await connection.ExecuteAsync(sql, new { lot.Ric, lot.Price, lot.Qty, lot.Date, lot.Commission, lot.Side, lot.PortfolioId });

                if (rows > 0)
                {
                    return true;
                }

                return false;
            }
        }

        public async Task<bool> DeleteAsync(int Id)
        {
            using (var connection = new SqlConnection(Configuration.GetValue<string>("ConnectionStrings:MarketData")))
            {
                connection.Open();
                var sql = $"DELETE FROM dbo.Lot where Id=@Id";
                int rows = await connection.ExecuteAsync(sql, new { Id });

                if (rows > 0)
                {
                    return true;
                }

                return false;
            }
        }

        public async Task<bool> UpdateAysnc(Lot lot)
        {
            using (var connection = new SqlConnection(Configuration.GetValue<string>("ConnectionStrings:MarketData")))
            {
                connection.Open();
                var sql = $"UPDATE [dbo].[Lot] SET  [Ric] = @Ric ,[Price] = @Price ,[Qty] = @Qty, [Date]=@Date, [Commission]=@Commission,[Side]=@Side,[PortfolioId]=@PortfolioId WHERE Id={lot.Id}";
                int rows = await connection.ExecuteAsync(sql, new { lot.Ric, lot.Price, lot.Qty, lot.Date, lot.Commission, lot.Side, lot.PortfolioId });

                if (rows > 0)
                {
                    return true;
                }

                return false;
            }
        }

        public async Task<IEnumerable<ILot>> GetSingleAsync(int id, DateTime asOf)
        {
            using (var connection = new SqlConnection(Configuration.GetValue<string>("ConnectionStrings:MarketData")))
            {
                connection.Open();
                var sql = $"select Id, Ric, Price, Qty , Date, Commission, Side, PortfolioId from dbo.Lot where PortfolioId={id} and Date <= '{asOf}'";
                return await connection.QueryAsync<Lot>(sql);
            }

        }
    }
}
