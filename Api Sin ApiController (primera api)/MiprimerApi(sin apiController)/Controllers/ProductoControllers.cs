using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
//using MiprimerApi_sin_apiController_.Controllers;
using MiprimerApi_sin_apiController_.Models;
using Microsoft.AspNetCore.Mvc.ApiExplorer;


namespace MiprimerApi_sin_apiController_.Controllers
{

    [Route("/api/Productos")]
    public class ProductoController : Controller
    {
        //[Route("controller/Producto")]

        //llamé la "tabla" la clase de producto aqui para añadirle manualmente los atributos
        private static List<Producto> productos = new List<Producto>
        {
            new Producto { Id = 1, Nombre = "Camisa", Precio = 25.5m, Stock = 10 },
            new Producto { Id = 2, Nombre = "Pantalón", Precio = 40.0m, Stock = 5 }
        };


        //metodos de una api: GET, POST, DELETE Y PUL

        //GET=OBTENER
        //POST= CREAR
        //PUT= MODIFICAR 
        //DELETE = ELIMINAR

        //asi se crea el metodo GET de la api

        [HttpGet] //se le dice que es el get con esto
        public IActionResult Obtener(int id) //puede llamarse como quiera, como el metodo de Insertar en Ado.net
        { 
            return new JsonResult(productos); //se encapsula el elemento 
        }


        [HttpGet("{id}")] //como siempre se busca por id y te devuelve el 
        public IActionResult ObtenerporID(int id)
        {
            var producto = productos.FirstOrDefault(p=> p.Id == id);
            if (producto == null) 
                return NotFound("Objeto no encontrado");

            return new JsonResult(producto);
        }

        [HttpPost]
        public IActionResult Crear([FromBody]Producto agregarProducto)
        {
            if (agregarProducto == null)
                return BadRequest("No se agregó producto");

            if (string.IsNullOrEmpty(agregarProducto.Nombre))
                return BadRequest("No se agregó nombre");

            agregarProducto.Id= productos.Max(p => p.Id)+1; //le asigna el id automaticamente

            productos.Add(agregarProducto); //agrega el producto nuevo como en entityFramework
            return Created($"/api/producto/{agregarProducto.Id}", agregarProducto); 
        }



        [HttpPut]
        public IActionResult ModificarPUT([FromBody]Producto modificarProducto)
        {
            //primer intento, a bateo

            //if (modificarProducto == null)
            //    return BadRequest("No ha modificado no ha digitado");

            //var verificar= productos.FirstOrDefault(p=>p.Id == modificarProducto.Id);

            //if (verificar == null)
            //    return BadRequest("Id no valido");
            //productos.Update(modificarProducto);
            //return Created($"/api/producto/{modificarProducto.Id}", modificarProducto);

            //verificar si hay proudcto a modificar
            if (modificarProducto == null)
                return BadRequest("No ha modificado no ha digitado");

            var verificar = productos.FirstOrDefault(p => p.Id == modificarProducto.Id);

            //se verifica que el producto exista
            if (verificar == null)
                return BadRequest("Id no valido");

            verificar.Nombre= modificarProducto.Nombre;
            verificar.Precio= modificarProducto.Precio;
            verificar.Stock= modificarProducto.Stock;

            return Ok (verificar); //0 simplemente : return Nocontent();s
        }

        //primer intento, a bateo de eliminar 

        //[HttpDelete]
        //public IActionResult EliminarDelete([FromBody] Producto eliminarProducto)
        //{
        //    //primer intento, a bateo

        //    //verificar si hay proudcto a modificar
        //    if (eliminarProducto == null)
        //        return BadRequest("No ha eliminado no ha digitado");

        //    var verificar = productos.FirstOrDefault(p => p.Id == eliminarProducto.Id);

        //    //se verifica que el producto exista
        //    if (verificar == null)
        //        return BadRequest("Id no valido");
        //    //elimina el que se buscó, no el que uno digita, por eso no se usa el "eliminarProducto"
        //    productos.Remove(verificar);
        //    return Ok(verificar);
        //}

        [HttpDelete("{id}")]
        public IActionResult EliminarDelete(int id)
        { 
            var verificar= productos.FirstOrDefault(p=> p.Id == id);

            if (verificar == null)
            {
                return NotFound("Id invalido, objeto no encontrado");

            }

            productos.Remove(verificar);
            return Ok(verificar);
        
        }
    }
}
