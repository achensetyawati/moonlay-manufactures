using Moonlay.Baas.Manufactures.Controllers;
using Moonlay.Manufactures.Application;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Moonlay.Baas.Manufactures.Tests.Controllers
{
    public class OrdersControllerTests : IDisposable
    {
        private MockRepository mockRepository;

        private Mock<IManufactureOrderService> mockManufactureOrderService;

        public OrdersControllerTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);

            this.mockManufactureOrderService = this.mockRepository.Create<IManufactureOrderService>();
        }

        public void Dispose()
        {
            this.mockRepository.VerifyAll();
        }

        private OrdersController CreateOrdersController()
        {
            return new OrdersController(
                this.mockManufactureOrderService.Object);
        }

        [Fact]
        public async Task Get_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var unitUnderTest = CreateOrdersController();

            // Act
            var result = await unitUnderTest.Get();

            // Assert
        }
    }
}
