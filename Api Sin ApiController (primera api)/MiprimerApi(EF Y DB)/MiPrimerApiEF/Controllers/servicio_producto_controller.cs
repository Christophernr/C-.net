    using MiPrimerApiEF.Models;
    using MiPrimerApiEF.conexion;
    using Microsoft.AspNetCore.Mvc;
    using MiPrimerApiEF.DTOs;


namespace MiPrimerApiEF.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ServicioProductoController: ControllerBase
    {

        //nueva manera de hacer una instancia 
        private readonly conexionDB conexionDB;

        public ServicioProductoController(conexionDB conexiones)
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
        public IActionResult Post([FromBody] tablaPOSTdto crear)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);

            }

            var llamar = new tabla_producto()
            {
                
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

        [HttpPut]
        public IActionResult Put([FromBody] tablaPUTdto crear)
        {
            if (ModelState.IsValid)
            { 
                var llamarObjeto= conexionDB.tabla_producto.FirstOrDefault(p=> p.Id == crear.Id);

                if (llamarObjeto == null)
                {
                    return NotFound("No se eoncotró objeto a modificar");
                
                }

                llamarObjeto.Name = crear.Name;
                llamarObjeto.Description = crear.Description;
                llamarObjeto.Precio = crear.Precio;
                

                conexionDB.Update(llamarObjeto);
                conexionDB.SaveChanges();
                return Ok(llamarObjeto);
            }else
                return BadRequest(ModelState);
            
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var llamarObjeto= conexionDB.tabla_producto.FirstOrDefault(p=> p.Id== id); 

            if (llamarObjeto == null)
                return NotFound("NO se encontró objeto");

            conexionDB.Remove(llamarObjeto);
            conexionDB.SaveChanges();
            return Ok(llamarObjeto);
        }
    }

}
