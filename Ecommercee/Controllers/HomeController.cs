using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecommercee.Libraries.Email;
using Ecommercee.Models;
using Microsoft.AspNetCore.Mvc;

namespace Ecommercee.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ContatoAcao()
        {
            try
            {
                Contato contato = new Contato();
                contato.Nome = HttpContext.Request.Form["nome"];
                contato.Email = HttpContext.Request.Form["email"];
                contato.Texto = HttpContext.Request.Form["texto"];

                //Para funcionar o código abaixo de envio de Email descomentar a linha abaixo e inserir a senha da conta na classe ContatoEmail, e especificar um return adequado
                ContatoEmail.EnviarContatoPorEmail(contato);

                ViewData["MSG_S"] = "Mensagem de contato enviado com sucesso!"; /* Mensagem de aviso que aparecerá após o envio do formulário for concluído com sucesso */
            }
            catch (Exception e)
            {
                ViewData["MSG_E"] = "Opss! Tivemos um erro, tente novamente mais tarde!";

                //Gravar a Exceção em um Log
                //TODO - Implementar Log
            }

            return View("Contato"); /* Retorna para a mesma tela após realizar a requisição do envio do formulário */
        }

        public IActionResult Contato()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult CadastroCliente()
        {
            return View();
        }

        public IActionResult CarrinhoCompras()
        {
            return View();
        }
    }
}
