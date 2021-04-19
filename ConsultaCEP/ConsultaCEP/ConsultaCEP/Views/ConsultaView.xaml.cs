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
    public partial class ConsultaView : ContentPage
    {
        public ConsultaView()
        {
            InitializeComponent();

            this.BindingContext = new ConsultaViewModel();
        }
    }
}