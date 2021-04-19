using ConsultaCEP.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace ConsultaCEP.Interface
{
    public interface IGeolocalizacaoService
    {
        Task<Location> Geolocalizacao(Endereco Endereco);
    }
}
