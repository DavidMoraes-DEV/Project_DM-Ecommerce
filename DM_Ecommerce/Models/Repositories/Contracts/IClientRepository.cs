﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DM_Ecommerce.Models.Repositories.Contracts
{
    public interface IClientRepository
    {
        Client Login(string Email, string Senha);

        //CRUD
        void Cadastrar(Client client);
        void Atualizar(Client client);
        void Excluir(int Id);
        Client ObterClient(int Id);
        IEnumerable<Client> ObterTodosClients();
    }
}
