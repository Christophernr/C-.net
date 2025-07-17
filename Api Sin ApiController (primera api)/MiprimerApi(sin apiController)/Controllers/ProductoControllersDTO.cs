using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using MiprimerApi_sin_apiController_.Controllers;
using MiprimerApi_sin_apiController_.Models;
using Microsoft.AspNetCore.Mvc.ApiExplorer;

    
namespace MiprimerApi_sin_apiController_.Controllers.dto
{

    [Route("/api/ProductoControllersDTO")]
    public class ProductoControllersDTO : Controller
    {
        //llamé la "tabla" la clase de ProductoconDTOcs aqui para añadirle manualmente los atributos
        private static List<Producto> FakeProducto = new List<Producto>
        {

        };

        //metodos de una api: GET, POST, DELETE Y PUL

        //GET=OBTENER
        //POST= CREAR
        //PUT= MODIFICAR 
        //DELETE = ELIMINAR


        [HttpGet]
        public IActionResult BuscarGet(int id)
        {
            //var traerProducto = new Producto();

            return new JsonResult(FakeProducto);                       
        }

        [HttpPost]
        public IActionResult CrearPOST([FromBody] ProductoconDTOcs crear)
        {
            if (!ModelState.IsValid)   //aqui se valida si esta bien con las validaciones de la tabla
                return BadRequest(ModelState); //devuelve si esta vacio el nombre o si el precio no es mayor

            var llamarProducto = new Producto() //llamo a la "original
            {

                Id =FakeProducto.Any()? FakeProducto.Max(productos=>productos.Id) + 1 : 1, //se pregunta si hay producto, si ya hay producto use el .Max, si no le asigna 1
                Nombre= crear.Nombre,
                Stock= crear.Stock,
                Precio= crear.Precio,
                fechaCreacion= DateTime.Now,
                UsuarioActivo= true
            };
            FakeProducto.Add(llamarProducto);
            
            return Ok(FakeProducto);
        }

        [HttpPut]
        public IActionResult ModificarPUT([FromBody] ProductoconDTOcs modificar)
        {
            if (!ModelState.IsValid)
                return NotFound(ModelState);

            var verificar = FakeProducto.FirstOrDefault(p => p.Id == modificar.Id);

            if (verificar == null)
                return NotFound ("No ha encontrado");

            verificar.Nombre = modificar.Nombre;
            verificar.Precio = modificar.Precio;
            verificar.Stock = modificar.Stock;

            return Ok(verificar);
        }
    }
}
