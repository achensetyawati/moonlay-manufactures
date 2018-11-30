using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Moonlay.Manufactures.Application;

namespace Moonlay.Baas.Manufactures.Controllers
{
    [Route("api/manufacture/orders")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IManufactureOrderService _manufactureOrderService;

        public OrdersController(IManufactureOrderService manufactureOrderService)
        {
            _manufactureOrderService = manufactureOrderService;
        }

        // GET api/values
        [HttpGet]
        public Task<IActionResult> Get()
        {
            throw new NotImplementedException();
        }

        
    }
}
