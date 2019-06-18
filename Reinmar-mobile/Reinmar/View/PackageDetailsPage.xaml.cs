using System;
using Reinmar.Common.Entities;
using Reinmar.Model;
using Reinmar.Providers;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Reinmar.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PackageDetailsPage : ContentPage
    {
        //private WaybillBody _waybillBody;
        private PackageModel _package;

        public PackageDetailsPage()
        {
            //_waybillBody = WaybillBodyProvider.waybillBody;
            _package = PackageProvider.package;

            InitializeComponent();


            orderName.Text = "\t" + _package.OrderName;

            receiverFullName.Text = "\t" + _package.ReceiverFullName;

            receiverEmail.Text = "\t" + _package.ReceiverEmail;

            phoneNumber.Text = "\t" + _package.PhoneNumber;

            country.Text = "\t" + _package.Country;

            notes.Text = "\t" + _package.Notes;

            streetNumber.Text = "\t" + _package.StreetName + " " + _package.HouseNumber;

            codeCity.Text = "\t" + _package.PostalCode + " " + _package.City;

            if(_package.Statuses.Count > 0)
            {
                status.Text = "\t" + _package.Statuses[_package.Statuses.Count - 1].Event;
            }
            else
            {
                status.Text = "\t" + "Ready to send";
            }


        //CargoName.Text = _waybillBody.CargoName;
        //Quantity.Text = _waybillBody.Quantity.ToString();

        //FullName.Text = _waybillBody.WaybillHeaders.FullName;
        //StreetNameAndHouseNumber.Text =
        //    _waybillBody.WaybillHeaders.StreetName +
        //    " " + _waybillBody.WaybillHeaders.HouseNumber;
        //City.Text = _waybillBody.WaybillHeaders.City;
        //PhoneNumber.Text = _waybillBody.WaybillHeaders.PhoneNumber;
        //Notes.Text = _waybillBody.WaybillHeaders.Notes;
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