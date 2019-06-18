using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reinmar.Providers;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Reinmar.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LoggedPage : ContentPage
	{
		public LoggedPage ()
		{
			InitializeComponent ();
		}

        async void ButtonLogOutClicked(object sender, EventArgs e)
        {
            Button button = sender as Button;
            TokenProvider.token = null;
            await Navigation.PopToRootAsync();
        }

        async void ButtonChangePackageStatusClicked(object sender, EventArgs e)
        {
            Button button = sender as Button;
            await Navigation.PushAsync(new PackageStatusPage());
        }

        async void ButtonFindPackageClicked(object sender, EventArgs e)
        {
            Button button = sender as Button;
            await Navigation.PushAsync(new FindPackagePage());
        }
    }
}