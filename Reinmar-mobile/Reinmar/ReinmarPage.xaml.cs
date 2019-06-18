using Reinmar.View;
using System;
using Xamarin.Forms;

namespace Reinmar
{
    public partial class ReinmarPage : ContentPage
    {
        public ReinmarPage()
        {
            InitializeComponent();
        }

        async void ButtonClicked(object sender, EventArgs e)
        {
            Button button = sender as Button;
            await Navigation.PushAsync(new LoginPage());
        }
    }
}
