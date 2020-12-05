using DM_Ecommerce.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DM_Ecommerce.Models.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private DM_EcommerceContext _banco;
        public ClientRepository(DM_EcommerceContext banco)
        {
            _banco = banco;
        }

        public void Atualizar(Client client)
        {
            _banco.Update(client);
            _banco.SaveChanges();
        }

        public void Cadastrar(Client client)
        {
            _banco.Add(client);
            _banco.SaveChanges();
        }

        public void Excluir(int Id)
        {
            Client client = ObterClient(Id);
            _banco.Remove(client);
            _banco.SaveChanges();
        }

        public Client Login(string Email, string Senha)
        {
            Client client = _banco.Clients.Where(m => m.Email == Email && m.Senha == Senha).First();
            return client;
        }

        public Client ObterClient(int Id)
        {
            return _banco.Clients.Find(Id);
        }

        public List<Client> ObterTodosClients()
        {
            return _banco.Clients.ToList();
        }
    }
}
