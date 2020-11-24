using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DM_Ecommerce.Libraries.Email;
using DM_Ecommerce.Models;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DM_Ecommerce.Controllers
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

                //Validações dos dados do formulário fornecido pelo usuário
                var ListMessage = new List<ValidationResult>(); /* Para cada validação é possível ser lançada uma mensagem de erro */
                var context = new ValidationContext(contato); /* Realiza a validação dos dados da variável conforme as regras de validação contidas na classe que a variável foi pertence */
                bool isValid = Validator.TryValidateObject(contato, context, ListMessage, true); /* Tenta validar o objeto passado, sendo o primeiro parâmetro recebido o próprio objeto, o segundo parâmetro é o contexto de validação desse objeto e o terceiro parâmetro que é a lista de mensagens caso de erro, sendo que o último parâmetro e um valor booleano para que seja verificado a validação de todos os itens antes de proseguir*/

                if (isValid) /* Se tudo estiver válido conforme verificação acima será enviado o e-mail */
                {
                    ContatoEmail.EnviarContatoPorEmail(contato);

                    ViewData["MSG_S"] = "Mensagem de contato enviado com sucesso!"; /* Mensagem de aviso que aparecerá após o envio do formulário for concluído com sucesso */
                }
                else
                {
                    StringBuilder sb = new StringBuilder();
                    foreach (var texto in ListMessage)
                    {
                        sb.Append(texto.ErrorMessage + "<br />");
                    }

                    ViewData["MSG_E"] = sb.ToString();
                    ViewData["CONTATO"] = contato;
                }

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
