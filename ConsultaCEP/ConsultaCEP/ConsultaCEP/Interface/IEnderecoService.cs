using ConsultaCEP.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ConsultaCEP.Interface
{
    public interface IEnderecoService
    {
        Task<Endereco> GetEnderecoCep(string pesquisa);
    }
}
