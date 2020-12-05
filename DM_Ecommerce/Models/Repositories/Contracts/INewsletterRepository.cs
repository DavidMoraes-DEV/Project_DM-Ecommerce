using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DM_Ecommerce.Models;

namespace DM_Ecommerce.Models.Repositories.Contracts
{
    public interface INewsletterRepository
    {
        void Cadastrar(NewsletterEmail newsletter);
        IEnumerable<NewsletterEmail> ObterTodasNewsletter();
    }
}
