using Moonlay.Manufactures.Domain;
using Moonlay.Manufactures.Domain.Entities;
using Moonlay.Manufactures.Domain.Repositories;
using Moonlay.Manufactures.Domain.ValueObjects;
using Moonlay.Manufactures.Events;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Moonlay.Manufactures.Application
{
    public class ManufactureOrderService : IManufactureOrderService
    {
        private readonly IProductRepository _productRepository;
        private readonly IManufactureOrderRepository _manufactureOrderRepository;
        private readonly IDepartmentRepository _departmentRepository;

        public ManufactureOrderService(IProductRepository productRepository,
            IDepartmentRepository departmentRepository, 
            IManufactureOrderRepository manufactureOrderRepository)
        {
            _productRepository = productRepository;
            _manufactureOrderRepository = manufactureOrderRepository;
            _departmentRepository = departmentRepository;
        }

        public async Task<ManufactureOrder> PlaceOrderAsync(string orderCode, Guid unitId, Guid flowId, Guid goodsId)
        {
            var goods = new Goods(_productRepository.GetProductById(goodsId));

            var unit = new UnitDepartment(_departmentRepository.GetDepartmentById(unitId));

            var flow = new ManufactureFlow(flowId, goods, new List<ManufactureOrderActivityType> {
                ManufactureOrderActivityType.Spinning_Blowing,
                ManufactureOrderActivityType.Spinning_Carding
            });

            var orderId = Guid.NewGuid();
            var order = new ManufactureOrder(orderId, orderCode, unit, flow, goods);

            order.AddDomainEvent(new OnManufactureOroderPlaced(orderId));

            await _manufactureOrderRepository.AddOrder(order);

            await _productRepository.UnitOfWork.SaveChangesAsync();

            return order;
        }
    }
}