using ConsultaCEP.Interface;
using ConsultaCEP.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ConsultaCEP.Services
{
    public class EnderecoService: IEnderecoService
    {
        private Requisicao requisicao = new Requisicao();
        public async Task<Endereco> GetEnderecoCep(string pesquisa)
        {
            Endereco endereco;
            try
            {
                var response = await requisicao.GetRequest("" + pesquisa + "/json/");
                endereco = JsonConvert.DeserializeObject<Endereco>(response);
            }
            catch (Exception ex)
            {
                endereco = null;
                Console.WriteLine(ex.Message);
            }
            return endereco;
        }
    }
}
