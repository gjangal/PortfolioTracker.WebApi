using Dapper;
using Microsoft.Extensions.Configuration;
using PortfolioTracker.WebApi.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace PortfolioTracker.WebApi.Repository
{
    public interface ICashRepository : IRepository<ICash>
    {
    }
    public class CashRepository : ICashRepository
    {
        private readonly IConfiguration configuration;

        public CashRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public bool Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DeleteAsync(int Id)
        {
            using (var connection = new SqlConnection(configuration.GetValue<string>("ConnectionStrings:MarketData")))
            {
                connection.Open();
                var sql = $"DELETE FROM dbo.Lot where Id=@lotId";
                int rows = await connection.ExecuteAsync(sql, new { Id });

                if (rows > 0)
                {
                    return true;
                }

                return false;
            }
        }

        public IEnumerable<ICash> GetList()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ICash>> GetListAsync()
        {
            using (var connection = new SqlConnection(configuration.GetValue<string>("ConnectionStrings:MarketData")))
            {
                connection.Open();
                var sql = $"select Id, PortfolioId, Amount, Date from dbo.Cash";
                return await connection.QueryAsync<Cash>(sql);
            }
        }

        public  ICash GetSingle(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task<ICash> GetSingleAsync(int Id)
        {
            using (var connection = new SqlConnection(configuration.GetValue<string>("ConnectionStrings:MarketData")))
            {
                connection.Open();
                var sql = $"select Id, PortfolioId, Amount, Date from dbo.Cash where Id={Id}";
                return (await connection.QueryAsync<Cash>(sql)).FirstOrDefault();
            }
        }

        public bool Insert(ICash lot)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> InsertAsync(ICash lot)
        {
            using (var connection = new SqlConnection(configuration.GetValue<string>("ConnectionStrings:MarketData")))
            {

                var sql = $"INSERT [dbo].[Cash] ([PortfolioId],[Amount],[Date]) VALUES ( @PortfolioId,@Amount,@Date)";
                int rows = await connection.ExecuteAsync(sql, new { lot.PortfolioId, lot.Amount, lot.Date });

                if (rows > 0)
                {
                    return true;
                }

                return false;
            }
        }

        public bool Update(ICash lot)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UpdateAysnc(ICash lot)
        {
            using (var connection = new SqlConnection(configuration.GetValue<string>("ConnectionStrings:MarketData")))
            {
                connection.Open();
                var sql = $"UPDATE [dbo].[Cash] SET  [PortfolioId] = @PortfolioId ,[Amount] = @Amount ,[Date]=@Date WHERE Id={lot.Id}";
                int rows = await connection.ExecuteAsync(sql, new { lot.PortfolioId, lot.Amount, lot.Date});

                if (rows > 0)
                {
                    return true;
                }

                return false;
            }
        }
    }
}
