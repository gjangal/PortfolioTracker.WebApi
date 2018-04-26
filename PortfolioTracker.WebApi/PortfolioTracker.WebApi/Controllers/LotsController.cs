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
        public LotsController(ILotRepository lotRepository)
        {

        }

        [HttpGet]
        public IEnumerable<Lot> GetAll()
        {
            return Enumerable.Empty<Lot>();
        }
    }
}