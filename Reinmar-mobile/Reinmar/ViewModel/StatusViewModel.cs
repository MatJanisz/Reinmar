using System;
using System.Threading.Tasks;
using Reinmar.Common.Entities;
using Reinmar.Providers;
using Reinmar.Service.Interface;

namespace Reinmar.ViewModel
{
    public class StatusViewModel
    {
        private IStatusService _statusService;

        public StatusViewModel(IStatusService statusService)
        {
            _statusService = statusService;
        }

        public async Task<Enums.Status> SetStatus(string statusEvent)
        {
            var response = await _statusService.AddStatus(WaybillBodyProvider.waybillBody, statusEvent, TokenProvider.token);
            return response;
        }
    }
}
