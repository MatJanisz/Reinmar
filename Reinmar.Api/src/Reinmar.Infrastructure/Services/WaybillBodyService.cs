using System;
using System.Collections.Generic;
using Reinmar.Common.Entities;
using Reinmar.Infrastructure.Repositories.Interfaces;
using Reinmar.Infrastructure.Services.Interfaces;

namespace Reinmar.Infrastructure.Services
{
    public class WaybillBodyService : IWaybillBodyService
    {
        private IWaybillBodyRepository _waybillBodyRepository;
        public WaybillBodyService(IWaybillBodyRepository waybillBodyRepository)
        {
            _waybillBodyRepository = waybillBodyRepository;
        }

        public WaybillBody Create(WaybillBody waybillBodies)
        {
            var random = new Random();
            waybillBodies.SitId = random.Next(1000000,9999999);
            _waybillBodyRepository.Add(waybillBodies);
            return waybillBodies;
        }

        public void Delete(WaybillBody entity)
        {
            _waybillBodyRepository.Delete(entity);
        }

        public IEnumerable<WaybillBody> GetAll()
        {
            return _waybillBodyRepository.GetAll();
        }

        public IEnumerable<WaybillBody> GetByHeaderId(Guid id)
        {
            return _waybillBodyRepository.GetByHeaderId(id);
        }

        public WaybillBody GetById(Guid id)
        {
            return _waybillBodyRepository.GetById(id);
        }

        public IEnumerable<WaybillBody> GetBySitId(int sitId)
        {
            return _waybillBodyRepository.GetBySitId(sitId);
        }

        public void Update(WaybillBody entity)
        {
            _waybillBodyRepository.Edit(entity);
        }
    }
}