using AutoMapper;
using Moonlay.Domain;
using Moonlay.Manufactures.Domain.ReadModels;
using Moonlay.Manufactures.Infrastructure;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Moonlay.Manufactures.Domain.Repositories
{
    public class ManufactureOrderRepository : IManufactureOrderRepository
    {
        private readonly ManufactureDbContext _context;
        private readonly IMapper _mapper;

        public ManufactureOrderRepository(ManufactureDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IUnitOfWork UnitOfWork => _context;

        public Task AddOrder(ManufactureOrder order)
        {
            var readModel = _mapper.Map<ManufactureOrder, ManufactureOrderReadModel>(order);

            readModel.TransferDomainEvents(order);

            _context.ManufactureOrders.Add(readModel);

            return Task.CompletedTask;
        }

        public Task<IQueryable<ManufactureOrder>> GetAllAsync()
        {
            throw new NotImplementedException();
        }
    }
}