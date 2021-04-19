using ConsultaCEP.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace ConsultaCEP.ViewModels
{
    [QueryProperty(nameof(Cep), nameof(Cep))]
    public class EnderecoDetalhesViewModel : BaseViewModel
    {
        private string _cep;
        public string Cep
        {
            get => _cep;
            set
            {
                SetProperty(ref _cep, value);
                CarregarEndereco();
            }
        }

        private Endereco _endereco;
        public Endereco Endereco
        {
            get => _endereco;
            set => SetProperty(ref _endereco, value);
        }

        public void CarregarEndereco()
        {
            Endereco = RealmService.BuscarCEP(Cep);
        }
    }
}
