using ACME.CQRS;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks; 

//Utiliza los controladores para manejar las solicitudes web, delegando la lógica de negocio a los handlers correspondientes.
namespace ACME.Controllers
{
    public class Inventario_Controller : Controller
    {
        public IActionResult Index()
        {

            return View();
        }

        public IActionResult Detalles(int id)
        {
            return View();
        }

        private readonly GetInventarioHandler _getInventarioHandler;

        public Inventario_Controller(GetInventarioHandler getInventarioHandler)
        {
            _getInventarioHandler = getInventarioHandler;
        }

        public async Task<IActionResult> Index(int sucursalId)
        {
            var query = new GetInventarioQuery { SucursalId = sucursalId };
            var inventario = await _getInventarioHandler.Handle(query);
            return View(inventario); // Asumiendo que tienes una vista Index configurada para mostrar el inventario
        }
    }
}