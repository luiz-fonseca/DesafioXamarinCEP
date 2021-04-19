using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms.Maps;

namespace ConsultaCEP.ViewModels
{
    public class MapaViewModel : BaseViewModel
    {
        public static Map Mapa;

        public MapaViewModel()
        {
            Mapa = new Map();
        }

        public void CarregarInformacoes()
        {
            Mapa.Pins.Clear();

            var locais = RealmService.Enderecos();

            if (locais.Count > 0)
            {
                Mapa.MoveToRegion(MapSpan.FromCenterAndRadius(
                 new Position(locais[0].Latitude, locais[0].Longitude), Distance.FromKilometers(2000)));

                foreach (var item in locais)
                {
                    var pin = new Pin();
                    pin.Address = item.Logradouro;
                    pin.Label = item.Cep;
                    double latitude = item.Latitude;
                    double longitude = item.Longitude;
                    pin.Position = new Position(latitude, longitude);
                    pin.Type = PinType.Place;
                    Mapa.Pins.Add(pin);
                }
            }

        }
    }
}
