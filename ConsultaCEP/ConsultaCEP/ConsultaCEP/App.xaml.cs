using ConsultaCEP.Services;
using ConsultaCEP.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: ExportFont("fa-solid-900.ttf", Alias = "FontAwesome")]

namespace ConsultaCEP
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<RealmService>();
            DependencyService.Register<GeolocalizacaoService>();
            DependencyService.Register<EnderecoService>();

            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
