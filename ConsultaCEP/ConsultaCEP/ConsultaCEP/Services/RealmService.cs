using ConsultaCEP.Interface;
using ConsultaCEP.Models;
using Realms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsultaCEP.Services
{
    public class RealmService: IRealmService
    {
        Realm _realm;

        public RealmService()
        {
            var config = RealmConfiguration.DefaultConfiguration;
            config.SchemaVersion = 1;
            this._realm = Realm.GetInstance(config);
            
        }
        
        public bool Inserir(Endereco endereco)
        {
            using (var transacao = _realm.BeginWrite())
            {
                try
                {
                    _realm.Add(endereco);
                    transacao.Commit();
                    return true;
                }
                catch(Exception ex)
                {
                    transacao.Rollback();
                    Console.WriteLine(ex.Message);
                    return false;
                }
            }
        }

        public Endereco BuscarCEP(string cep)
        {
            return _realm.Find<Endereco>(cep);
            
        }

        public List<Endereco> Enderecos()
        {
            return _realm.All<Endereco>().OrderByDescending(e => e.Cep).ToList();
        }

    }
}
