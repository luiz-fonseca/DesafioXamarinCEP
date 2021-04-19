using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ConsultaCEP.Services
{
    public class Requisicao
    {
        public async Task<string> GetRequest(string link)
        {
            HttpClient client = new HttpClient();
            string response = await client.GetStringAsync(Constantes.LinkWebServiceViaCep + link);
            return response;
        }
    }
}
