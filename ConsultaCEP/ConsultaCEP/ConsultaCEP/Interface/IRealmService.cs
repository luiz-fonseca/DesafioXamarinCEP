using ConsultaCEP.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsultaCEP.Interface
{
    public interface IRealmService
    {
        bool Inserir(Endereco endereco);
        Endereco BuscarCEP(string cep);
        List<Endereco> Enderecos();

    }
}
