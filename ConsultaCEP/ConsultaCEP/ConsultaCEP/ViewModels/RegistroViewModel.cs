using ConsultaCEP.Models;
using ConsultaCEP.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ConsultaCEP.ViewModels
{
    public class RegistroViewModel : BaseViewModel
    {
        private ObservableCollection<Endereco> _enderecos;
        public ObservableCollection<Endereco> Enderecos
        {
            get => _enderecos;
            set => SetProperty(ref _enderecos, value);
        }

        private Endereco _endereco;
        public Endereco Endereco
        {
            get => _endereco;
            set
            {
                SetProperty(ref _endereco, value);
                if(value != null)
                {
                    EnderecoSelecionado();
                }
            }
        }


        public RegistroViewModel()
        {
            this.Enderecos = new ObservableCollection<Endereco>();
        }

        public void CarregarEnderecos()
        {
            var enderecos = RealmService.Enderecos();
            if (enderecos?.Count > 0)
            {
                Enderecos = new ObservableCollection<Endereco>(enderecos);
            }
        }

        private async void EnderecoSelecionado()
        {
            await Shell.Current.GoToAsync($"EnderecoDetalhesView?Cep={Endereco.Cep}");
            Endereco = null;
        }
    }
}
