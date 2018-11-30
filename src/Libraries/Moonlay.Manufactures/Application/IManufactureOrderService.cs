using Moonlay.Manufactures.Domain;
using System;
using System.Threading.Tasks;

namespace Moonlay.Manufactures.Application
{
    public interface IManufactureOrderService
    {
        Task<ManufactureOrder> PlaceOrderAsync(string orderCode, Guid unitId, Guid flowId, Guid goodsId);
    }
}