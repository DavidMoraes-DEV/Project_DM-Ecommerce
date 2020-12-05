using DM_Ecommerce.DataBase;
using DM_Ecommerce.Models.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DM_Ecommerce.Models.Repositories
{
    public class NewsletterRepository : INewsletterRepository
    {
        private DM_EcommerceContext _banco;
        public NewsletterRepository(DM_EcommerceContext banco)
        {
            _banco = banco;
        }

        public void Cadastrar(NewsletterEmail newsletter)
        {
            _banco.NewsletterEmails.Add(newsletter);
            _banco.SaveChanges();
        }

        public IEnumerable<NewsletterEmail> ObterTodasNewsletter()
        {
            return _banco.NewsletterEmails.ToList();
        }
    }
}
