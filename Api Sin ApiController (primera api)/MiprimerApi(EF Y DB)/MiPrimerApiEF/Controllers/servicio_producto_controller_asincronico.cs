using Microsoft.EntityFrameworkCore;
using MiPrimerApiEF.Models;
using MiPrimerApiEF.conexion;
using Microsoft.AspNetCore.Mvc;
using MiPrimerApiEF.DTOs;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace MiPrimerApiEF.Controllers
{

    [ApiController]
    [Route("api/Controller")]
    public class ServicioProductoControllerAsync: ControllerBase
    {

        private readonly conexionDB conexionDB;

        public ServicioProductoControllerAsync(conexionDB conecciones)
        {
            conexionDB = conecciones;

        }

        //obtener asincronico

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var producto = await conexionDB.tabla_producto.ToListAsync();

            if (producto == null || !producto.Any()) 
                return NotFound("No hay producctos");

            return Ok (producto);

        }


        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] tablaPOSTdto crear)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var llamar = new tabla_producto()
            {
                Name = crear.Name,
                Description = crear.Description,
                Precio = crear.Precio,
                Disponible = true,
                fechaIngreso = DateTime.Now


            };

            await conexionDB.AddAsync(llamar);
            await conexionDB.SaveChangesAsync();

            return Ok(llamar);

        }


        //modificar asincronico
        [HttpPut]
        public async Task<IActionResult> PUTAsync([FromBody] tablaPUTdto modificar)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);

            }

            var llamarObjeto= await conexionDB.tabla_producto.FirstOrDefaultAsync(p=> p.Id == modificar.Id);

            if(llamarObjeto == null)
                return NotFound("No existe objeto a modificar");

            llamarObjeto.Name = modificar.Name;
            llamarObjeto.Description = modificar.Description;
            llamarObjeto.Precio = modificar.Precio;

            
            await conexionDB.SaveChangesAsync();
            return Ok(llamarObjeto);
                
        }

        [HttpDelete("{id}")]

        public async Task<IActionResult> DeleteAsync(int id)
        {

            var llamarObjeto = await conexionDB.tabla_producto.FirstOrDefaultAsync(p=> p.Id== id);

            if (llamarObjeto == null)
            {
                return NotFound("No se ha encontrado para eliminar");

            }
            conexionDB.Remove(llamarObjeto);
            await conexionDB.SaveChangesAsync();
            return Ok(llamarObjeto);
        }

    }
}
