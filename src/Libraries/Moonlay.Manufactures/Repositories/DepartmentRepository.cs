using System;
using System.Linq;
using Moonlay.Domain;
using Moonlay.Manufactures.Domain.Entities;
using Moonlay.Manufactures.Infrastructure;

namespace Moonlay.Manufactures.Domain.Repositories
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly ManufactureDbContext _context;

        public DepartmentRepository(ManufactureDbContext context)
        {
            _context = context;
        }

        public IUnitOfWork UnitOfWork => _context;

        public Department GetDepartmentById(Guid id)
        {
            return _context.Departments.FirstOrDefault(o => o.Identity == id);
        }
    }
}
