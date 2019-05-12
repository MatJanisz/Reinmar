using System;
using System.Collections.Generic;
using Reinmar.Common.Entities;
using Reinmar.Infrastructure.Repositories.Interfaces;
using Reinmar.Infrastructure.Services.Interfaces;

namespace Reinmar.Infrastructure.Services
{
    public class WaybillHeaderService : IWaybillHeaderService
    {
        private IWaybillHeaderRepository _waybillHeaderRepository;
        public WaybillHeaderService(IWaybillHeaderRepository waybillHeaderRepository)
        {
            _waybillHeaderRepository = waybillHeaderRepository;
        }

        public void Create(WaybillHeader entity)
        {
            _waybillHeaderRepository.Add(entity);
        }

        public void Delete(WaybillHeader entity)
        {
            _waybillHeaderRepository.Delete(entity);
        }

        public IEnumerable<WaybillHeader> GetAll()
        {
            return _waybillHeaderRepository.GetAll();
        }

        public WaybillHeader GetById(Guid id)
        {
            return _waybillHeaderRepository.GetById(id);
        }

        public WaybillHeader GetBySitId(int sitId)
        {
            return _waybillHeaderRepository.GetBySitId(sitId);
        }

        public void Update(WaybillHeader entity)
        {
            _waybillHeaderRepository.Edit(entity);
        }
    }
}