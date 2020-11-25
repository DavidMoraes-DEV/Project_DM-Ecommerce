using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DM_Ecommerce.Models;
using Microsoft.EntityFrameworkCore;

namespace DM_Ecommerce.DataBase
{
    public class DM_EcommerceContext : DbContext
    {
        /* 
         * EF Core - ORM
            - ORM -> Biblioteca Mapear Objetos
            - Utilizando o ORM é possivel mapear as tabelas do banco de dados para objetos e Vice-Versa
            - Então o EntiteFrameWork que é um ORM, irá criar os SQL's necessários para conseguir trabalhar com esses dados
            - Resumindo o ORM é uma biblioteca que irá fazer o Mapeamento de objetos para tabelas de banco de dados relacionais
         */
        public DM_EcommerceContext(DbContextOptions<DM_EcommerceContext> options) : base(options)
        {

        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<NewsletterEmail> NewsletterEmails { get; set; }

    }
}
