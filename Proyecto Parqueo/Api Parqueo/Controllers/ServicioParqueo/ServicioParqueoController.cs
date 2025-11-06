using mainParqueo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using Api_Parqueo.DTOs;
using Api_Parqueo.DTOs.Parqueo;
//using Api_Parqueo.DTOs.Roles;

namespace Api_Parqueo.Controllers.ServicioParqueo
{
    [ApiController]
    [Route("api/[controller]")]
    public class ServicioParqueoController: ControllerBase
    {
        public readonly ConexionBD _ConexionBD;

        public ServicioParqueoController(ConexionBD conexionBD)
        {
            _ConexionBD = conexionBD;
        }

        [HttpGet]
        public async Task<IActionResult> GetParqueo() 
        {
            var Parqueo = await _ConexionBD.parqueos.ToListAsync();

            if (Parqueo == null) 
            {
                return NotFound("No encontrado");
            
            }

            return Ok();
        
        }


        [HttpPost]
        public async Task<IActionResult> PostParqueo([FromBody] DtoParqueoPost dtoParqueoPost)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            
            }

            var llamar = new Parqueo()
            {
                nombre = dtoParqueoPost.nombre,
                capacidadMaxima = dtoParqueoPost.capacidadMaxima,
                capacidadLey7600 = dtoParqueoPost.capacidadLey7600

            };

            _ConexionBD.Add(llamar);
            await _ConexionBD.SaveChangesAsync();
            return Ok(llamar);

        }

        [HttpPut]
        public async Task<IActionResult> PutParqueo([FromBody] DtoParqueoPut dtoParqueoPut)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var LlamarParqueo = await _ConexionBD.parqueos.FirstOrDefaultAsync(p=>p.id == dtoParqueoPut.id);

            if (LlamarParqueo == null)
            {
                return NotFound("No se encontró parqueo con ese ID para modificar");
            }

            LlamarParqueo.nombre = dtoParqueoPut.nombre;
            LlamarParqueo.capacidadMaxima = dtoParqueoPut.capacidadMaxima;
            LlamarParqueo.capacidadLey7600 = dtoParqueoPut.capacidadLey7600;


            _ConexionBD.Update(LlamarParqueo);
            await _ConexionBD.SaveChangesAsync();
            return Ok(LlamarParqueo);
        }

        [HttpDelete]

        public async Task<IActionResult> DeleteParqueo([FromBody] DtoParqueoDelete dtoParqueoDelete)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var LlamarParqueo = await _ConexionBD.parqueos.FirstOrDefaultAsync(p => p.id == dtoParqueoDelete.id);

            if(LlamarParqueo == null)
            {
                return NotFound("No se encontró parqueo con ese ID para eliminar");

            }

            _ConexionBD.Remove(LlamarParqueo);
            await _ConexionBD.SaveChangesAsync();
            return Ok();
        }
    }
}
