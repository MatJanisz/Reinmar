using System;
using Autofac;
using Reinmar.Providers;
using Reinmar.Service.Interface;
using Reinmar.Static;
using Reinmar.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Reinmar.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FindPackagePage : ContentPage
    {
        public FindPackagePage()
        {
            InitializeComponent();
        }

        async void ButtonFindPackageClicked(object sender, EventArgs e)
        {
            //var waybillBodyService = ContainerProvider.Container.Resolve<IWaybillBodyService>();
            //var waybillBodyViewModel = new WaybillBodyViewModel(waybillBodyService);
            //await waybillBodyViewModel.GetWaybillBody(int.Parse(SitId.Text));
            //if (WaybillBodyProvider.waybillBody != null)
            //{
            //    await Navigation.PushAsync(new PackageDetailsPage());
            //}

            var packageService = ContainerProvider.Container.Resolve<IPackageService>();
            var packageViewModel = new PackageViewModel(packageService);
            //await packageViewModel.GetPackage(int.Parse(SitId.Text));
            await packageViewModel.GetPackage(SitId.Text);
            if (PackageProvider.package != null)
            {
                await Navigation.PushAsync(new PackageDetailsPage());
            }
            else
            {
                this.DisplayAlert("You messed up!", "There is no package with provided sitId. :(", "Got it");
            }
            Button button = sender as Button;
        }

        async void ButtonLogOutClicked(object sender, EventArgs e)
        {
            Button button = sender as Button;
            TokenProvider.token = null;
            await Navigation.PopToRootAsync();
        }
    }
}