using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Mvc;
using Moonlay.Manufactures.Application;
using Moonlay.Manufactures.Domain;
using Moonlay.Manufactures.Domain.Repositories;
using Moonlay.Manufactures.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Moonlay.Baas.Manufactures.Controllers
{
    [Route("api/manufacture/orders")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IManufactureOrderService _manufactureOrderService;
        private readonly IManufactureOrderRepository _manufactureOrderRepository;
        private readonly IMapper _mapper;

        public OrdersController(IManufactureOrderService manufactureOrderService, IManufactureOrderRepository manufactureOrderRepository, IMapper mapper)
        {
            _manufactureOrderService = manufactureOrderService;
            _manufactureOrderRepository = manufactureOrderRepository;
            _mapper = mapper;
        }

        // GET api/values
        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(List<ManufactureOrderDto>))]
        public async Task<IActionResult> Get()
        {
            var data = await _manufactureOrderRepository.GetAllAsync();

            var result = data.ToArray().Select(o => _mapper.Map<ManufactureOrder, ManufactureOrderDto>(o)).ToList();

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]ManufactureOrderForm form)
        {
            var order = await _manufactureOrderService.PlaceOrderAsync(form.Code, Guid.Parse(form.UnitId), Guid.Parse(form.FlowId), Guid.Parse(form.OutputProductId));

            return Ok(order.Identity.ToString());
        }
    }
}