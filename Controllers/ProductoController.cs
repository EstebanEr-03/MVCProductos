using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Ejemplo1.Utils;
using Ejemplo1.Models;
using Ejemplo1.Services;
using Ejemplo1.API;

namespace Ejemplo1.Controllers
{
    public class ProductoController : Controller
    {
        private readonly IServicio_API _apiService;

        public ProductoController(IServicio_API apiService)
        {
            // Inyectamos la dependencia de nuestra interfaz para utilizar los métodos GET, POST, PUT y DELETE
            _apiService = apiService;
        }

        // GET: ProductoController
        public async Task<IActionResult> Index()
        {
            try
            {
                // Obtenemos la lista de productos a través de la API
                List<Producto> productos = await _apiService.GetProducto();
                return View(productos);
            }
            catch (Exception error)
            {
                // En caso de error, mostramos una vista vacía
                return View();
            }
        }

        // GET: ProductoController/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost] // Atributo para indicar un método HTTP POST
        public async Task<IActionResult> Create(Producto producto)
        {
            try
            {
                if (producto != null)
                {
                    // Invocamos la API para crear un nuevo producto
                    await _apiService.CreateProducto(producto);
                    // Redirigimos a la vista principal
                    return RedirectToAction("Index");
                }
            }
            catch (Exception error)
            {
                // En caso de error, mostramos una vista vacía
                return View();
            }
            return View();
        }

        // GET: ProductoController/Edit/5
        public async Task<IActionResult> Edit(int IdProducto)
        {
            try
            {
                // Buscamos un producto específico a través de la API por su ID
                Producto productoEncontrado = await _apiService.GetProductoByID(IdProducto);
                if (productoEncontrado != null)
                {
                    // Mostramos el producto en la vista de edición
                    return View(productoEncontrado);
                }
            }
            catch (Exception error)
            {
                // En caso de error, mostramos una vista vacía
                return View();
            }
            // Redirigimos a la vista principal si no encontramos el producto
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Producto nuevoProducto)
        {
            try
            {
                if (nuevoProducto != null)
                {
                    // Actualizamos el producto a través de la API utilizando su ID
                    await _apiService.UpdateProducto(nuevoProducto, nuevoProducto.IdProducto);
                    // Redirigimos a la vista principal después de la edición
                    return RedirectToAction("Index");
                }
                // En caso de error o datos nulos, mostramos una vista vacía
                return View();
            }
            catch (Exception error)
            {
                // En caso de error, mostramos una vista vacía
                return View();
            }
        }

        // GET: ProductoController/Delete/5
        public async Task<IActionResult> Delete(int IdProducto)
        {
            try
            {
                if (IdProducto != 0)
                {
                    // Eliminamos un producto por su ID a través de la API
                    await _apiService.DeleteProducto(IdProducto);
                    // Redirigimos a la vista principal después de la eliminación
                    return RedirectToAction("Index");
                }
            }
            catch (Exception error)
            {
                // En caso de error, mostramos una vista vacía
                return View();
            }
            // Redirigimos a la vista principal si el ID es 0 o no se puede eliminar el producto
            return RedirectToAction("Index");
        }
    }
}
