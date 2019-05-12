using System;
using System.Collections.Generic;
using Reinmar.Common.Entities;

namespace Reinmar.Infrastructure.Services.Interfaces
{
    public interface IWaybillBodyService
    {
        WaybillBody GetById(Guid id);

        IEnumerable<WaybillBody> GetAll();

        IEnumerable<WaybillBody> GetByHeaderId(Guid id);

        WaybillBody Create(WaybillBody entity);

        void Update(WaybillBody entity);

        void Delete(WaybillBody entity);
        IEnumerable<WaybillBody> GetBySitId(int sitId);
    }
}