using System;
using Reinmar.Common.Entities;

namespace Reinmar.Infrastructure.Services.Interfaces
{
    public interface IWaybillService
    {
        Waybill GetWaybillsById(Guid id);
        Waybill GetWaybillsBySitId(int sitId);
        void Create(Waybill waybill);
    }
}