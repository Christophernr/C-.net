using MiPrimerApiEF.Models;
using MiPrimerApiEF.conexion;
using Microsoft.AspNetCore.Mvc;


namespace MiPrimerApiEF.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class servicio_producto_controller: ControllerBase
    {

        //nueva manera de hacer una instancia 
        private readonly conexionDB conexionDB;

        public servicio_producto_controller(conexionDB conexiones)
        {

            conexionDB = conexiones;
        }
        [HttpGet]
        public IActionResult Get()
        {
            //return new JsonResult(conexionDB);   //asi era antes sin sql

            var productos= conexionDB.tabla_producto;

            if(productos == null)
            {

                return NotFound("NO encontrado");
            }

            return Ok (productos);
        
        }
        [HttpPost]
        public IActionResult Post([FromBody] tabla_productoDTO crear)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);

            }

            var llamar = new tabla_producto()
            {
                Id = crear.Id,
                Name = crear.Name,
                Description = crear.Description,
                Precio = crear.Precio,
                Disponible = true,
                fechaIngreso = DateTime.Now

            };
            conexionDB.Add(llamar);
            conexionDB.SaveChanges();
            return Ok(llamar);


        }
    }
}
