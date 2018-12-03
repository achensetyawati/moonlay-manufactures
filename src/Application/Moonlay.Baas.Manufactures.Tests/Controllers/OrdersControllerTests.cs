using AutoMapper;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moonlay.Baas.Manufactures.Controllers;
using Moonlay.Manufactures.Application;
using Moonlay.Manufactures.Domain;
using Moonlay.Manufactures.Domain.Entities;
using Moonlay.Manufactures.Domain.Repositories;
using Moonlay.Manufactures.Domain.ValueObjects;
using Moonlay.Manufactures.Dtos;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Moonlay.Baas.Manufactures.Tests.Controllers
{
    public class OrdersControllerTests : IDisposable
    {
        private readonly MockRepository mockRepository;

        private readonly Mock<IManufactureOrderService> mockManufactureOrderService;
        private readonly Mock<IManufactureOrderRepository> mockManufactureOrderRepo;
        private readonly Mock<IMapper> mockMapper;

        public OrdersControllerTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);

            this.mockManufactureOrderService = this.mockRepository.Create<IManufactureOrderService>();
            this.mockManufactureOrderRepo = this.mockRepository.Create<IManufactureOrderRepository>();

            this.mockMapper = this.mockRepository.Create<IMapper>();
        }

        public void Dispose()
        {
            this.mockRepository.VerifyAll();
        }

        private OrdersController CreateOrdersController()
        {
            return new OrdersController(
                this.mockManufactureOrderService.Object,
                this.mockManufactureOrderRepo.Object,
                this.mockMapper.Object);
        }

        [Fact]
        public async Task Get_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var unitUnderTest = CreateOrdersController();

            //fake

            var goodsId = Guid.NewGuid();
            var product = new Goods(goodsId, "Benang 401");

            var unitId = Guid.NewGuid();

            var unit = new UnitDepartment(unitId, "Spinning");

            var flowId = Guid.NewGuid();

            var flow = new ManufactureFlow(flowId, product, new List<ManufactureOrderActivityType> {
                ManufactureOrderActivityType.Spinning_Blowing,
                ManufactureOrderActivityType.Spinning_Carding
            });

            var orderCode = "MO010101";

            var order = new ManufactureOrder(Guid.NewGuid(), orderCode, unit, flow, product);

            var orders = new List<ManufactureOrder>() {
                order
            };

            this.mockManufactureOrderRepo.Setup(x => x.GetAllAsync()).Returns(Task.FromResult(orders.AsQueryable()));

            this.mockMapper.Setup(x => x.Map<ManufactureOrder, ManufactureOrderDto>(It.IsAny<ManufactureOrder>()))
                .Returns(new ManufactureOrderDto
                {
                    Id = order.Identity.ToString(),
                    Code = order.Code
                });

            // Act
            var result = await unitUnderTest.Get();

            // Assert

            result.Should().BeOfType<OkObjectResult>()
                .Subject.Value.Should().BeOfType<List<ManufactureOrderDto>>()
                .Subject.Count.Should().BeGreaterThan(0);
        }

        [Fact]
        public async Task Post_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var unitUnderTest = CreateOrdersController();

            //fake

            var goodsId = Guid.NewGuid();
            var product = new Goods(goodsId, "Benang 401");

            var unitId = Guid.NewGuid();

            var unit = new UnitDepartment(unitId, "Spinning");

            var flowId = Guid.NewGuid();

            var flow = new ManufactureFlow(flowId, product, new List<ManufactureOrderActivityType> {
                ManufactureOrderActivityType.Spinning_Blowing,
                ManufactureOrderActivityType.Spinning_Carding
            });

            var orderCode = "MO010101";

            var order = new ManufactureOrder(Guid.NewGuid(), "MO010101", unit, flow, product);

            this.mockManufactureOrderService.Setup(x => x.PlaceOrderAsync(orderCode, unitId, flowId, goodsId)).Returns(Task.FromResult(order));

            var form = new ManufactureOrderForm
            {
                Code = orderCode,
                UnitId = unitId.ToString(),
                FlowId = flowId.ToString(),
                OutputProductId = goodsId.ToString()
            };

            // Act
            IActionResult result = await unitUnderTest.Post(form);

            // Assert
            result.Should().BeOfType<OkObjectResult>()
               .Subject.Value.Should().BeOfType<string>()
               .Subject.Should().Be(order.Identity.ToString());
        }
    }
}