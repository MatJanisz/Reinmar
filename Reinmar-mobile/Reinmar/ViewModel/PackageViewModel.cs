using System;
using System.Threading.Tasks;
using Reinmar.Providers;
using Reinmar.Service.Interface;

namespace Reinmar.ViewModel
{
    public class PackageViewModel
    {
        private IPackageService _packageService;

        public PackageViewModel(IPackageService packageService)
        {
            _packageService = packageService;
        }

        public async Task<Enums.Status> GetPackage(string sitId)
        {
            //var sitId2 = int.Parse(sitId);
            var response = await _packageService.GetPackage(sitId, TokenProvider.token);

            if (response == null)
            {
                PackageProvider.package = null;
                return Enums.Status.Failed;
            }

            PackageProvider.package = response;
            return Enums.Status.Ok;
        }

        public async Task<Enums.Status> SetStatus(string sitId, string location, string statusEvent)
        {
            var response = await _packageService.ChangeStatus(sitId, location, statusEvent, TokenProvider.token);
            return response;
        }
    }
}
