using Ecommercee.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Ecommercee.Libraries.Email
{
    public class ContatoEmail
    {
        public static void EnviarContatoPorEmail(Contato contato)
        {
            /* SMTP -> Servidor que vai enviar a mensagem! */
            SmtpClient smtp = new SmtpClient("smtp-relay.gmail.com", 587);
            smtp.UseDefaultCredentials = false; /*Configura para que nao seja utilizado as configuracoes iniciais padrao das credenciais */
            smtp.Credentials = new NetworkCredential("InvestTraderrs@gmail.com", "");
            smtp.EnableSsl = true;

            /* MaiMessage -> Contruir a Mensagem */
            MailMessage mensagem = new MailMessage();

        }
    }
}
