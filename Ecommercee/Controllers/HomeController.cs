﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
            Contato contato = new Contato();
            contato.Nome = HttpContext.Request.Form["nome"];
            contato.Email = HttpContext.Request.Form["email"];
            contato.Texto = HttpContext.Request.Form["texto"];

            return new ContentResult() { Content = string.Format("Dados recebidos com Sucesso!!! <br/>Nome: {0} <br/>E-mail: {1} <br/>Texto: {2}", contato.Nome, contato.Email, contato.Texto), ContentType = "text/html" };
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
