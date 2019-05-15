using System;
using Reinmar.Common.Entities;
using Reinmar.Providers;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Reinmar.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PackageDetailsPage : ContentPage
    {
        private WaybillBody _waybillBody;

        public PackageDetailsPage()
        {
            _waybillBody = WaybillBodyProvider.waybillBody;

            InitializeComponent();

            //CargoName.Text = _waybillBody.CargoName;
            //Quantity.Text = _waybillBody.Quantity.ToString();
            FullName.Text = _waybillBody.WaybillHeaders.FullName;
            StreetNameAndHouseNumber.Text =
                _waybillBody.WaybillHeaders.StreetName +
                " " + _waybillBody.WaybillHeaders.HouseNumber;
            City.Text = _waybillBody.WaybillHeaders.City;
            PhoneNumber.Text = _waybillBody.WaybillHeaders.PhoneNumber;
            Notes.Text = _waybillBody.WaybillHeaders.Notes;
        }

        async void ButtonFindPackageClicked(object sender, EventArgs e)
        {
            Button button = sender as Button;
            await Navigation.PopAsync();
        }

        async void ButtonChangeStatusClicked(object sender, EventArgs e)
        {
            Button button = sender as Button;
            await Navigation.PushAsync(new PackageStatusPage());
        }
    }
}