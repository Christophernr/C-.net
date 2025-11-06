using mainParqueo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using Api_Parqueo.DTOs;
using Api_Parqueo.DTOs.Roles;
using Api_Parqueo.infrastructure.command.ServicioRolesCommand;
using Api_Parqueo.infrastructure.command.ServicioRolesUsuarioCommand;

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

            var command = new CreateServicioRoles(_ConexionBD);
            var crearRol= await command.CreateRol(dtoTablaPost);

            //esto se usa en el command, ya no se ocupa aqui para nada
            //var llamar = new Roles()
            //{
            //    rol = dtoTablaPost.rol
            //};

            //_ConexionBD.Add(llamar);
            //await _ConexionBD.SaveChangesAsync();
            return Ok(crearRol);
        }

        [HttpPut]
        public async Task<IActionResult> PutRoles([FromBody] DtoRolPut dtoTablaPut)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var command = new UpdateRol(_ConexionBD);
            var editarRol= await command.UpdateRoles(dtoTablaPut);
            //tampoco hace falta aqui porque y esta en el command

            //var LlamarRol = await _ConexionBD.roles.FirstOrDefaultAsync(p => p.id == dtoTablaPut.id);

            //if(LlamarRol == null)
            //{
            //    return BadRequest("No se encontró Rol");
            //}
            
            //LlamarRol.rol = dtoTablaPut.rol;


            //_ConexionBD.Update(LlamarRol);
            //await _ConexionBD.SaveChangesAsync();
            return Ok(editarRol);            
        }


            [HttpDelete("{id_rol}")]
            public async Task<IActionResult> DeleteRol([FromBody] DtoRolPut dtoTablaDelete)
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var command = new DeleteRoles(_ConexionBD);
                var eliminarRol = await command.DeleteRol(id_rol);

                if (!eliminarRol)
                {
                    return Ok(eliminarRol);
                }

                return BadRequest("No se eliminó el objeto");

            }
    }
}
