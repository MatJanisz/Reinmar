using Autofac;
using Reinmar.Providers;
using Reinmar.Service.Interface;
using Reinmar.Static;
using Reinmar.ViewModel;
using System;
using Xamarin.Forms;

namespace Reinmar.View
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        async void ButtonLogInClicked(object sender, EventArgs e)
        {
            var loginService = ContainerProvider.Container.Resolve<ILoginService>();
            var loginPageViewModel = new LoginPageViewModel(loginService);
            await loginPageViewModel.Login(login.Text, password.Text);
            if (TokenProvider.token != null)
            {
                await Navigation.PushAsync(new LoggedPage());
            }
            else
            {
                this.DisplayAlert("You messed up!", "Your login or password is wrong. Or both. :(", "Got it");
            }
        }
    }
}
