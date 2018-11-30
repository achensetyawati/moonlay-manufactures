using Moonlay.Domain;
using System.Linq;
using System.Threading.Tasks;

namespace Moonlay.Manufactures.Domain.Repositories
{
    public interface IManufactureOrderRepository : IRepository<ManufactureOrder>
    {
        Task<IQueryable<ManufactureOrder>> GetAllAsync();

        Task AddOrder(ManufactureOrder order);
    }
}