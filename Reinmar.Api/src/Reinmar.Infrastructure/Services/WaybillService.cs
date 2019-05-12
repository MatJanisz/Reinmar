using System;
using Reinmar.Common.Entities;
using Reinmar.Infrastructure.Repositories.Interfaces;
using Reinmar.Infrastructure.Services.Interfaces;

namespace Reinmar.Infrastructure.Services
{
    public class WaybillService : IWaybillService
    {
        private IWaybillRepository _waybillRepository;
        public WaybillService(IWaybillRepository waybillRepository)
        {
            _waybillRepository = waybillRepository;
        }

        public void Create(Waybill waybill)
        {
            _waybillRepository.Add(waybill);
        }

        public Waybill GetWaybillsById(Guid id)
        {
            return _waybillRepository.GetById(id);
        }

        public Waybill GetWaybillsBySitId(int sitId)
        {
            return _waybillRepository.GetBySitId(sitId);
        }
    }
}