using ConsultaCEP.Interface;
using ConsultaCEP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace ConsultaCEP.Services
{
    public class GeolocalizacaoService: IGeolocalizacaoService
    {
        public async Task<Location> Geolocalizacao(Endereco Endereco)
        {
            Location localizacao = null;
            try
            {
                var endereco = Endereco.Logradouro + " " + Endereco.Bairro + " " + Endereco.Cep
                    + " " + Endereco.Localidade + " " + Endereco.Uf + " Brasil" ;
                var localizacoes = await Geocoding.GetLocationsAsync(endereco);

                localizacao = localizacoes?.FirstOrDefault();
                if (localizacao != null)
                {
                    return localizacao;
                }
            }
            catch (FeatureNotSupportedException fnsEx)
            {
               //UserDialogs.Instance.Toast("Este recurso não é suportado pelo seu dispositivo", TimeSpan.FromSeconds(3));
                // Feature not supported on device

            }
            catch (Exception ex)
            {
                //UserDialogs.Instance.Toast("Ops! Ocorreu um erro na busca da sua localização, tente novamente mais tarde", TimeSpan.FromSeconds(3));
                // Handle exception that may have occurred in geocoding
            }
            return localizacao;
        }
    }
}
