using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

//Utiliza los controladores para manejar las solicitudes web, delegando la lógica de negocio a los handlers correspondientes.
namespace ACME.Controllers
{
    public class ProductoController : Controller
    {
        public IActionResult Index()
        {

            return View();
        }

        public IActionResult Detalles(int id)
        {
            return View();
        }
    }
}
