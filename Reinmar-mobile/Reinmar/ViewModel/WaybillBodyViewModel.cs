using System;
using System.Threading.Tasks;
using Reinmar.Common.Entities;
using Reinmar.Providers;
using Reinmar.Service.Interface;

namespace Reinmar.ViewModel
{
    public class WaybillBodyViewModel
    {
        private IWaybillBodyService _waybillBodyService;

        public WaybillBodyViewModel(IWaybillBodyService waybillBodyService)
        {
            _waybillBodyService = waybillBodyService;
        }

        public async Task<Enums.Status> GetWaybillBody(int sitId)
        {
            var response = await _waybillBodyService.GetWaybillBody(sitId, TokenProvider.token);

            if(response == null)
            {
                WaybillBodyProvider.waybillBody = null;
                return Enums.Status.Failed;
            }

            WaybillBodyProvider.waybillBody = response;
            return Enums.Status.Ok;
        }
    }
}
