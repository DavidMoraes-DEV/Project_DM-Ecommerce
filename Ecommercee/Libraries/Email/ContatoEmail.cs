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
            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            smtp.UseDefaultCredentials = false; /*Configura para que nao seja utilizado as configuracoes iniciais padrao das credenciais */
            smtp.Credentials = new NetworkCredential("InvestTraderrs@gmail.com", ""); /* Para funcionar antes é necessário inserir a senha da conta do Email especificado aqui */
            smtp.EnableSsl = true;

            string corpoMsg = string.Format("<h2>Contato - DM-Ecommerce</h2>" +
                "<b>Nome: </b> {0} <br />" +
                "<b>E-mail: </b> {1} <br />" +
                "<b>Texto: </b> {2} <br />" +
                "<br /> E-mail enviado automaticamente do site LojaVirtual.",
                contato.Nome,
                contato.Email,
                contato.Texto
            );


            /*
             * MailMessage -> Construir a mensagem
             */
            MailMessage mensagem = new MailMessage();
            mensagem.From = new MailAddress("InvestTraderRS@gmail.com");
            mensagem.To.Add("DavidM.designergrafico@gmail.com");
            mensagem.Subject = "Contato - DM-Ecommerce - E-mail: " + contato.Email;
            mensagem.Body = corpoMsg;
            mensagem.IsBodyHtml = true;

            //Envia a Mensagem via SMTP
            smtp.Send(mensagem);
        }
    }
}
