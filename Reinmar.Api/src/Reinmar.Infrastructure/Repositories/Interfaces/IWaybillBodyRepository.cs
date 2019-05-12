using System;
using System.Collections.Generic;
using Reinmar.Common.Entities;

namespace Reinmar.Infrastructure.Repositories.Interfaces
{
    public interface IWaybillBodyRepository : IRepository<WaybillBody>
    {
         IEnumerable<WaybillBody> GetByHeaderId(Guid id);
         IEnumerable<WaybillBody> GetBySitId(int sitId);
    }
}