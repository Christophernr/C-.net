using Api_Parqueo.DTOs;
using Api_Parqueo.DTOs.RolesUsuario;
using mainParqueo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Api_Parqueo.Controllers.ServicioRolesUsuario
{
    public class ServicioRolesUsuarioController : ControllerBase
    {
        public readonly ConexionBD _conexionBD;

        public ServicioRolesUsuarioController(ConexionBD conexionBD)
        {
            _conexionBD = conexionBD;
        }

        private async Task<List<RolesUsuario>> LigarUsuario()
        {
            var RolesUsuario = await  _conexionBD.rolesUsuarios
            .Include(v => v.Usuario)
            .Include(v=> v.roles)
            .ToListAsync();


            return RolesUsuario;


        }

        [HttpGet]
        public  async Task<IActionResult> GetRolesUsuario()
        {

            var RolesUsuario = await LigarUsuario();

            if(RolesUsuario == null)
            {
                return NotFound("NO existe");
            }

            var respuesta = RolesUsuario.Select(v => new DtoRolesUsuarioRespuesta
            {
                id_usuario_fk = v.id_usuario_fk,
                usuario = v.Usuario.usuario,
                rol = v.roles.rol,
            });

            
            return Ok(respuesta);
        }


        [HttpPost]
        public async Task<IActionResult> PostRolesUsuario([FromBody] DtoRolesUsuarioPost dtoRolesUsuarioPost)
        {
            var RolesUsuario = await LigarUsuario();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var llamar = new RolesUsuario()
            {
                id_role_fk = dtoRolesUsuarioPost.id_role_fk,
                id_rol_usuario = dtoRolesUsuarioPost.id_usuario_fk,

            };

            _conexionBD.Add(llamar);
            await _conexionBD.SaveChangesAsync();


            var respuesta = RolesUsuario.Select(v => new DtoRolesUsuarioRespuesta()
            {
                id_usuario_fk = v.id_usuario_fk,
                rol = v.roles.rol,
                usuario = v.Usuario.usuario,

            });

            return Ok(respuesta);
        }

        [HttpPut]

        public async Task<IActionResult> PutRolesUsuario([FromBody] DtoRolesUsuarioPut dtoRolesUsuarioPut)
        {
            var RolesUsuario= await LigarUsuario();

            if(!ModelState.IsValid) return BadRequest(ModelState);

            var llamar = new RolesUsuario()
            {
                id_role_fk = dtoRolesUsuarioPut.id_role_fk,
                id_usuario_fk = dtoRolesUsuarioPut.id_rol_usuario,


            };

            
            _conexionBD.Update(llamar);
            await _conexionBD.SaveChangesAsync();

            var respuesta = RolesUsuario.Select(v => new DtoRolesUsuarioRespuesta()
            {
                id_usuario_fk = v.id_usuario_fk,
                rol = v.roles.rol,
                usuario = v.Usuario.usuario,
            });

            return Ok(respuesta);

        }

        [HttpDelete]
        public async Task<IActionResult> DeleteRolesUsuario([FromBody] DtoRolesUsuarioDelete dtoRolesUsuarioDelete)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var llamarRolesUsuario= await _conexionBD.rolesUsuarios.FirstOrDefaultAsync(p=>p.id_rol_usuario == dtoRolesUsuarioDelete.id_rol_usuario);

            if(llamarRolesUsuario == null) return BadRequest("Usuario no encontrado");

            _conexionBD.Remove(llamarRolesUsuario);

            await _conexionBD.SaveChangesAsync();
            return Ok();


        }
    }
}
