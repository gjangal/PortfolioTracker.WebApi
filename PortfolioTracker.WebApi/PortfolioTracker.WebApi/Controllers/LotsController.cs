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
    
    public class LotsController : Controller
    {
        private readonly ILotRepository lotRepository;

        public LotsController(ILotRepository lotRepository)
        {
            this.lotRepository = lotRepository;
        }

        [Route("api/Lots")]
        [HttpGet]
        public async Task<IEnumerable<Lot>> GetAll()
        {
            return await lotRepository.GetListAsync();
        }

        [Route("api/Lots")]
        [HttpPost]
        public async Task<bool> Post([FromBody]Lot lot)
        {
            return await lotRepository.InsertAsync(lot);
        }

        [Route("api/Lots/{id}")]
        [HttpGet]
        public async Task<Lot> Get(int id)
        {
            return await lotRepository.GetSingleAsync(id);
        }

        [Route("api/Lots/{id}")]
        [HttpDelete]
        public async Task<bool> Delete(int id)
        {
            return await lotRepository.DeleteAsync(id);
        }

        [Route("api/Lots/")]
        [HttpPut]
        public async Task<bool> Put([FromBody]Lot lot)
        {
            return await lotRepository.UpdateAysnc(lot);
        }
    }
}