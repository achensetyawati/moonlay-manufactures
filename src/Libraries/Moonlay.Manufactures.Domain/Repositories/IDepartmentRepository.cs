using Moonlay.Domain;
using Moonlay.Manufactures.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Moonlay.Manufactures.Domain.Repositories
{
    public interface IDepartmentRepository : IRepository<Department>
    {
        Department GetDepartmentById(Guid unitId);
    }
}
