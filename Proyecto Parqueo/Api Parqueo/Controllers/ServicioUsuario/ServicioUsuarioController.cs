using Api_Parqueo.DTOs;
using Api_Parqueo.DTOs.Usuario;
using mainParqueo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Cryptography;
using System.Text;
namespace Api_Parqueo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ServicioUsuarioController: ControllerBase
    {
        public readonly ConexionBD _ConexionBD;


        public ServicioUsuarioController(ConexionBD conexionBD)
        {
            _ConexionBD = conexionBD;
        }

        private string GenerarSalt()
        {
            byte[] saltBytes = new byte[32];

            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(saltBytes);
            }

            return Convert.ToBase64String(saltBytes);

        }

        public static string HashPassword(string password, string salt)
        {
            using (var sha256 = SHA256.Create())
            {
                // Combinar password + salt
                var combined = password + salt;
                var bytes = Encoding.UTF8.GetBytes(combined);

                // Hashear
                var hash = sha256.ComputeHash(bytes);
                return Convert.ToBase64String(hash);
            }
        }
    

        [HttpGet]
        public async Task<IActionResult> GetUsuario()
        {
            var Usuario = await _ConexionBD.usuarios.ToListAsync();

            if (Usuario == null)
            {
                return NotFound("No encontrado");
            }

            var respuesta = Usuario.Select(u => new DtoUsuarioRespuesta
            {
                Id= u.id_usuario,
                Email= u.email,
                Nombre= u.nombre,
                Usuario= u.usuario,
                FechaRegistro= u.FechaIngreso,


            });

            return Ok(respuesta);

        }

        [HttpPost]
        public async Task<IActionResult> PostUsuario([FromBody] DtoUsuarioPost dtoUsuarioPost)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            //generar salt 

            string salt= GenerarSalt();

            //hashear contraseña (password + salt)

            string passwordHash = HashPassword(dtoUsuarioPost.password, salt);

            var llamar = new Usuario()
            {
                nombre = dtoUsuarioPost.nombre,
                email = dtoUsuarioPost.email,
                //password = dtoUsuarioPost.password,
                usuario = dtoUsuarioPost.usuario,
                PasswordHash = passwordHash,
                Salt = salt,
                FechaIngreso = DateTime.Now,

            };

            _ConexionBD.Add(llamar);
            await _ConexionBD.SaveChangesAsync();
            return Ok(
                new DtoUsuarioRespuesta
                {
                    Id = llamar.id_usuario,
                    Usuario = llamar.usuario,
                    Nombre = llamar.nombre,
                    Email = llamar.email,
                    FechaRegistro = llamar.FechaIngreso,
                }
            );
        }


        [HttpPut]
        public async Task<IActionResult> PutUsuario([FromBody] DtoUsuarioPut dtoUsuarioPut)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var LLamarUsuario = await _ConexionBD.usuarios.FirstOrDefaultAsync(p => p.id_usuario == dtoUsuarioPut.Id);

            if(LLamarUsuario == null)
            {
                return BadRequest("Usuario no encontrado con ese ID");
            }

            LLamarUsuario.usuario = dtoUsuarioPut.usuario;
            LLamarUsuario.email = dtoUsuarioPut.email;
            LLamarUsuario.nombre = dtoUsuarioPut.nombre;

            _ConexionBD.Update(LLamarUsuario);
            await _ConexionBD.SaveChangesAsync();
            return Ok(new DtoUsuarioRespuesta
            {
                Id= LLamarUsuario.id_usuario,
                Nombre= LLamarUsuario.nombre,
                Email= LLamarUsuario.email,
                Usuario= LLamarUsuario.usuario,
                
            });
        }


        [HttpDelete]
        public async Task<IActionResult> DeleteUsuario([FromBody] DtoUsuarioDelete dtoUsuarioDelete)
        {
            if(!ModelState.IsValid)
                { return BadRequest(ModelState); }

            var LLamarUsuario= await _ConexionBD.usuarios.FirstOrDefaultAsync(p=>p.usuario == dtoUsuarioDelete.usuario);

            if( LLamarUsuario == null) { return BadRequest("Usuario no encontrado"); }

            _ConexionBD.Remove(LLamarUsuario);
            await _ConexionBD.SaveChangesAsync(); 
            return Ok();
        }
    }
}
