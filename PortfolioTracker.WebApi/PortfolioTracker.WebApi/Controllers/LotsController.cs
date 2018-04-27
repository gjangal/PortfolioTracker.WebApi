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
    [Route("api/Lots")]
    public class LotsController : Controller
    {
        private readonly ILotRepository lotRepository;

        public LotsController(ILotRepository lotRepository)
        {
            this.lotRepository = lotRepository;
        }

        [HttpGet]
        public IEnumerable<Lot> GetAll()
        {
            return lotRepository.GetList();
        }
    }
}