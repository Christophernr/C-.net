using mainParqueo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using Api_Parqueo.DTOs;
using Api_Parqueo.DTOs.Roles;

namespace Api_Parqueo.Controllers.ServicioRoles
{
    [ApiController]
    [Route("api/[controller]")]
    public class ServicioRolesController: ControllerBase
    {
                    public readonly ConexionBD _ConexionBD;

        public ServicioRolesController(ConexionBD conexionBD)
        { 
            _ConexionBD = conexionBD;
        }


        [HttpGet]
        public async Task<IActionResult> GetRoles() 
        {
            var Roles = await _ConexionBD.roles.ToListAsync();

            if (Roles == null) 
            {
                return NotFound("No encontrado");
            }
            
            return Ok(Roles);
        }

        [HttpPost]
        public async Task<IActionResult> PostRoles([FromBody] DtoRolPost dtoTablaPost) 
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var llamar = new Roles()
            {
                rol = dtoTablaPost.rol
            };

            _ConexionBD.Add(llamar);
            await _ConexionBD.SaveChangesAsync();
            return Ok(llamar);
        }

        [HttpPut]
        public async Task<IActionResult> PutRoles([FromBody] DtoRolPut dtoTablaPut)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var LlamarRol = await _ConexionBD.roles.FirstOrDefaultAsync(p => p.id == dtoTablaPut.id);

            if(LlamarRol == null)
            {
                return BadRequest("No se encontró Rol");
            }
            
            LlamarRol.rol = dtoTablaPut.rol;


            _ConexionBD.Update(LlamarRol);
            await _ConexionBD.SaveChangesAsync();
            return Ok(LlamarRol);            
        }


        [HttpDelete]
        public async Task<IActionResult> DeleteRol([FromBody] DtoRolPut dtoTablaDelete)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var llamarRol= await _ConexionBD.roles.FirstOrDefaultAsync(p=>p.id == dtoTablaDelete.id);
 
            if (llamarRol == null)
            {
                return BadRequest("No se encontró Rol");
            }

            _ConexionBD.Remove(llamarRol);
            await _ConexionBD.SaveChangesAsync();
            return Ok();

        }
    }
}
