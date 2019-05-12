using System;
using System.Collections.Generic;
using Reinmar.Common.Entities;

namespace Reinmar.Infrastructure.Services.Interfaces
{
    public interface IWaybillHeaderService
    {
        WaybillHeader GetById(Guid id);

        WaybillHeader GetBySitId(int sitId);

        IEnumerable<WaybillHeader> GetAll();

        void Create(WaybillHeader entity);

        void Update(WaybillHeader entity);

        void Delete(WaybillHeader entity);
    }
}