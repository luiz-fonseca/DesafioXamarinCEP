using Newtonsoft.Json;
using Realms;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsultaCEP.Models
{
    public class Endereco : RealmObject
    {
        [JsonProperty(PropertyName = "cep")]
        [PrimaryKey]
        public string Cep { get; set; }

        [JsonProperty(PropertyName = "logradouro")]
        public string Logradouro { get; set; }

        [JsonProperty(PropertyName = "complemento")]
        public string Complemento { get; set; }

        [JsonProperty(PropertyName = "bairro")]
        public string Bairro { get; set; }

        [JsonProperty(PropertyName = "localidade")]
        public string Localidade { get; set; }

        [JsonProperty(PropertyName = "uf")]
        public string Uf { get; set; }

        [JsonProperty(PropertyName = "ibge")]
        public string Ibge { get; set; }

        [JsonProperty(PropertyName = "gia")]
        public string Gia { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}
