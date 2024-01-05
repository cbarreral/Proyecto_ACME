using ACME.CQRS;
using ACME.Data;
using ACME.Models;
using ACME.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

//Utiliza los controladores para manejar las solicitudes web, delegando la lógica de negocio a los handlers correspondientes.
namespace ACME.Controllers
{
    public class InventarioController : Controller
    {

        private readonly IInventarioRepository _inventarioRepository;
        private readonly GetInventarioHandler _getInventarioHandler;
        public IActionResult Index()
        {

            return View();
        }

        public IActionResult Detalles(int id)
        {
            return View();
        }
        public IActionResult Crear()
        {
            return View();  // Retorna una vista con un formulario para añadir un nuevo producto
        }

        [HttpPost]
        public async Task<IActionResult> Crear(InventarioModel nuevoInventario)
        {
            if (ModelState.IsValid)
            {
                await _inventarioRepository.AgregarInventarioAsync(nuevoInventario);
                return RedirectToAction("ObtenerInventarioPorSucursal"); // Redirige al listado de inventario
            }
            return View(nuevoInventario);  // Si hay un error, vuelve a mostrar el formulario
        }

        public async Task<IActionResult> Editar(int id)
        {
            InventarioModel inventario = await _inventarioRepository.ObtenerInventarioPorIdAsync(id);
            if (inventario == null)
            {
                return NotFound();  // No se encontró el inventario
            }
            return View(inventario);  // Retorna la vista con los detalles del inventario a editar
        }

        [HttpPost]
        public async Task<IActionResult> Editar(int id, InventarioModel inventarioModificado)
        {
            if (ModelState.IsValid)
            {
                await _inventarioRepository.ActualizarInventarioAsync(id,inventarioModificado);
                return RedirectToAction("ObtenerInventarioPorSucursal"); // Redirige al listado de inventario
            }
            return View(inventarioModificado);  // Si hay un error, vuelve a mostrar el formulario
        }

        public async Task<IActionResult> Eliminar(int id)
        {
            await _inventarioRepository.EliminarInventarioAsync(id);
            return RedirectToAction("ObtenerInventarioPorSucursal"); // Redirige al listado de inventario
        }


        public InventarioController(IInventarioRepository inventarioRepository)
        {
            _inventarioRepository = inventarioRepository;
        }

        public async Task<IActionResult> ObtenerInventarioPorSucursal(int sucursalId)
        {
            var inventario = await _inventarioRepository.GetInventarioPorSucursalAsync(sucursalId);
            return View(inventario);  
        }

        public InventarioController(GetInventarioHandler getInventarioHandler)
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