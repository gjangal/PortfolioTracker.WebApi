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
        public IEnumerable<Lot> GetAll()
        {
            return lotRepository.GetList();
        }

        [Route("api/Lots")]
        [HttpPost]
        public bool Post([FromBody]Lot lot)
        {
            return lotRepository.Insert(lot);
        }

        [Route("api/Lots/{id}")]
        [HttpGet]
        public Lot Get(int id)
        {
            return lotRepository.GetSingle(id);
        }

        [Route("api/Lots/{id}")]
        [HttpDelete]
        public bool Delete(int id)
        {
            return lotRepository.Delete(id);
        }

        [Route("api/Lots/")]
        [HttpPut]
        public bool Put([FromBody]Lot lot)
        {
            return lotRepository.Update(lot);
        }
    }
}