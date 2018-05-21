using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PortfolioTracker.WebApi.Model;
using PortfolioTracker.WebApi.Repository;

namespace PortfolioTracker.WebApi.Controllers
{
    [Produces("application/json")]
    public class CashController : Controller
    {
        private readonly ICashRepository cashRepository;

        public CashController(ICashRepository cashRepository)
        {
            this.cashRepository = cashRepository;
        }

        [Route("api/Cash")]
        [HttpGet]
        public async Task<IEnumerable<ICash>> GetAllAsync()
        {
            return await cashRepository.GetListAsync();
        }

        [Route("api/Cash")]
        [HttpPost]
        public async Task<bool> Post([FromBody]ICash lot)
        {
            return await cashRepository.InsertAsync(lot);
        }

        [Route("api/Cash/{id}")]
        [HttpGet]
        public async Task<ICash> Get(int id)
        {
            return await cashRepository.GetSingleAsync(id);
        }

        [Route("api/Cash/{id}")]
        [HttpDelete]
        public async Task<bool> Delete(int id)
        {
            return await cashRepository.DeleteAsync(id);
        }

        [Route("api/Cash/")]
        [HttpPut]
        public async Task<bool> Put([FromBody]ICash lot)
        {
            return await cashRepository.UpdateAysnc(lot);
        }

    }
}