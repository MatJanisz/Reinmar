using System;
using System.Collections.Generic;
using Autofac;
using Reinmar.Service.Interface;
using Reinmar.Static;
using Reinmar.ViewModel;
using Xamarin.Forms;

namespace Reinmar.View
{
    public partial class PackageStatusPage : ContentPage
    {
        public PackageStatusPage()
        {
            InitializeComponent();
        }

        async void ButtonChangeStatusClicked(object sender, EventArgs e)
        {
            var statusService = ContainerProvider.Container.Resolve<IStatusService>();
            var statusViewModel = new StatusViewModel(statusService);
            await statusViewModel.SetStatus(StatusPicker.SelectedItem.ToString());
            DisplayAlert("All good!", "We've got it!", "I've got it, too...");
            await Navigation.PopAsync();
        }

        async void ButtonFindPackageClicked(object sender, EventArgs e)
        {
            Button button = sender as Button;
            await Navigation.PushAsync(new FindPackagePage());
        }
    }
}
