using Microsoft.AspNetCore.Mvc;
using DM_Ecommerce.Models;
using DM_Ecommerce.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace DM_Ecommerce.Controllers
{
    public class ProductController : Controller /* Todo controlodor herda da classe "Controller" e essa classe pertence ao nameSpace: "Microsoft.AspNetCore.Mvc" */
    {
        /* Para cada ACAO existira um metodo que representara essa acao e o metodo necessitará possuir o mesmo nome da acao */
        public ActionResult Visualizar() /* Todo metodo retorna um Action Result (resultado da acao) ou uma variacao dele sendo uma Interface que he a "IActionResult" */
        {
            Product produto = GetProduct();


            return View(produto);
            /*return new ContentResult() { Content = "<h3>Produto -> Visualizar</h3>", ContentType = "text/html" };*/
        }

        private Product GetProduct()
        {
            return new Product()
            {
                Id = 1,
                Name = "Xbox One X",
                Description = "Jogue em 4K",
                Value = 2000.00M
            };
        }
    }
}