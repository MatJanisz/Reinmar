using Reinmar.Common.Entities;
using Reinmar.Infrastructure.Repositories.Interfaces;
using Reinmar.Infrastructure.Services.Interfaces;

namespace Reinmar.Infrastructure.Services
{
    public class StatusService : IStatusService
    {
        private IStatusRepository _statusRepository;
        public StatusService(IStatusRepository statusRepository)
        {
            _statusRepository = statusRepository;
        }
        public void Add(Status entity)
        {
            _statusRepository.Add(entity);
        }

        public void Edit(Status entity)
        {
            _statusRepository.Edit(entity);
        }
    }
}