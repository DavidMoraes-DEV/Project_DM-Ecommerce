using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Ecommercee.Controllers
{
    public class ProductController : Controller /* Todo controlodor herda da classe "Controller" e essa classe pertence ao nameSpace: "Microsoft.AspNetCore.Mvc" */
    {
        /* Para cada ACAO existira um metodo que representara essa acao e o metodo necessitará possuir o mesmo nome da acao */
        public ActionResult Visualizar() /* Todo metodo retorna um Action Result (resultado da acao) ou uma variacao dele sendo uma Interface que he a "IActionResult" */
        {
            return new ContentResult() { Content = "<h3>Produto -> Visualizar</h3>", ContentType = "text/html" };
        }
    }
}
