using Autofac;
using Reinmar.Service;
using Reinmar.Service.Interface;
using Reinmar.Static;
using Reinmar.View;
using Xamarin.Forms;

namespace Reinmar
{
    public partial class App : Application
    {
        public App()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<LoginService>().As<ILoginService>();
            builder.RegisterType<StatusService>().As<IStatusService>();
            builder.RegisterType<WaybillBodyService>().As<IWaybillBodyService>();
            ContainerProvider.Container = builder.Build();

            InitializeComponent();

            MainPage = new NavigationPage(new ReinmarPage());
            //MainPage = new ReinmarPage();
        }

        protected override void OnStart()
        {

        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
