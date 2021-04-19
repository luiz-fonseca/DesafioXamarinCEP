using ConsultaCEP.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ConsultaCEP.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MapaView : ContentPage
    {
        public MapaView()
        {
            InitializeComponent();

            this.BindingContext = new MapaViewModel();
            MapaViewModel.Mapa = map;
        }

        protected override void OnAppearing()
        {
            (BindingContext as MapaViewModel)?.CarregarInformacoes();
            base.OnAppearing();
        }
    }
}