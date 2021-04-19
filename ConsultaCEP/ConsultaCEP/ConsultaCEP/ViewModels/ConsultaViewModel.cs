using ConsultaCEP.Models;
using ConsultaCEP.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace ConsultaCEP.ViewModels
{
    public class ConsultaViewModel : BaseViewModel
    {
        private string _pesquisa;
        public string Pesquisa
        {
            get => _pesquisa;
            set => SetProperty(ref _pesquisa, value);
        }

        public Command PesquisarCommand { get; }

        public ConsultaViewModel()
        {
            this.PesquisarCommand = new Command(async () => await BuscarCEP());
        }

        private async Task BuscarCEP()
        {
            var current = Connectivity.NetworkAccess;
            if (current == NetworkAccess.Internet)
            {
                var endereco = await EnderecoService.GetEnderecoCep(Pesquisa);
                if (!string.IsNullOrWhiteSpace(endereco?.Cep))
                {
                    string mensagem = "CEP: " + endereco.Cep + "\n" +
                        "Logradouro: " + endereco.Logradouro + "\n" +
                        "Complemento: " + endereco.Complemento + "\n" +
                        "Bairro: " + endereco.Bairro + "\n" +
                        "Localidade: " + endereco.Localidade + "\n" +
                        "UF: " + endereco.Uf + "\n" +
                        "IBGE: " + endereco.Ibge + "\n" +
                        "Gia: " + endereco.Gia;

                    await App.Current.MainPage.DisplayAlert("Endereço",mensagem, "Ok");

                    endereco = await Geolocalizacao(endereco);
                    await InserirEndereco(endereco);

                }
                else
                {
                    await App.Current.MainPage.DisplayAlert("Endereço", "Não foi possível encontrar o endereço deste CEP", "Ok");
                }

            }
            else
            {
                await App.Current.MainPage.DisplayAlert("Internet", "Você está sem conexão com a internet, tente novamente mais tarde", "Ok");
            }
        }

        private async Task<Endereco> Geolocalizacao(Endereco endereco)
        {
            var localidade = await GeolocalizacaoService.Geolocalizacao(endereco);
            if (localidade != null)
            {
                endereco.Latitude = localidade.Latitude;
                endereco.Longitude = localidade.Longitude;
            }
            return endereco;
        }

        public async Task InserirEndereco(Endereco endereco)
        {
            var result = RealmService.BuscarCEP(endereco.Cep);
            if (result == null)
            {
                var cadastro = RealmService.Inserir(endereco);
                if (cadastro)
                {
                    await App.Current.MainPage.DisplayAlert("Endereço", "Endereço cadastrado com sucesso!", "Ok");
                }
                else
                {
                    await App.Current.MainPage.DisplayAlert("Endereço", "Falha ao cadastar o endereço, tente novamente mais tarde!", "Ok");
                }
            }
            else
            {
                await App.Current.MainPage.DisplayAlert("Endereço", "Ops! Este CEP já está cadastrado ", "Ok");
            }
        }
    }
}
