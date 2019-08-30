using LyaStudio;
using LyaStudio.Views;
using System;
using System.Net;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace LyaStudio
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();


#if DEBUG
            HotReloader.Current.Run(this, new HotReloader.Configuration {


                ExtensionIpAddress = IPAddress.Parse("192.168.15.38")

            });
#endif

            MainPage = new NavigationPage( new ListagemView());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
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
