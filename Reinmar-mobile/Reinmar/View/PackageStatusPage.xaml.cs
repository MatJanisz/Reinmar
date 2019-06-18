using System;
using System.Collections.Generic;
using Autofac;
using Reinmar.Model;
using Reinmar.Providers;
using Reinmar.Service.Interface;
using Reinmar.Static;
using Reinmar.ViewModel;
using Xamarin.Forms;

namespace Reinmar.View
{
    public partial class PackageStatusPage : ContentPage
    {
        private PackageModel _package;

        public PackageStatusPage()
        {
            _package = PackageProvider.package;

            InitializeComponent();

            //if (_package.Statuses.Count > 0)
            //{
            //    StatusPicker.SelectedItem = _package.Statuses[_package.Statuses.Count - 1].Event;
            //}
        }

        async void ButtonChangeStatusClicked(object sender, EventArgs e)
        {
            if(location.Text == null || StatusPicker.SelectedItem == null)
            {
                DisplayAlert("You messed up!", "Both location and status have to be entered", "Got it");
            }
            else
            {
                var packageService = ContainerProvider.Container.Resolve<IPackageService>();
                var packageViewModel = new PackageViewModel(packageService);
                await packageViewModel.SetStatus(_package.SitId, location.Text, StatusPicker.SelectedItem.ToString());
                DisplayAlert("All good!", "Status succesfully changed", "Got it");
                //await Navigation.PopAsync();
                await Navigation.PushAsync(new FindPackagePage());
            }

            //var statusService = ContainerProvider.Container.Resolve<IStatusService>();
            //var statusViewModel = new StatusViewModel(statusService);
            //await statusViewModel.SetStatus(StatusPicker.SelectedItem.ToString());
            //DisplayAlert("All good!", "We've got it!", "I've got it, too...");
            //await Navigation.PopAsync();
        }

        async void ButtonFindPackageClicked(object sender, EventArgs e)
        {
            Button button = sender as Button;
            await Navigation.PushAsync(new FindPackagePage());
        }
    }
}
