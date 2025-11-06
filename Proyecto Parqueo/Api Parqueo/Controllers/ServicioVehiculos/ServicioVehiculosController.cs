using Api_Parqueo.DTOs.Parqueo;
using mainParqueo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Api_Parqueo.DTOs;
using Api_Parqueo.DTOs.Vehiculos;

namespace Api_Parqueo.Controllers.ServicioVehiculos
{
    [ApiController]
    [Route("api/[controller]")]
    public class ServicioVehiculosController: ControllerBase
    {
        public readonly ConexionBD _ConexionBD;

        public ServicioVehiculosController(ConexionBD conexionBD)
        {
            _ConexionBD = conexionBD;
        }

        [HttpGet]
        public async Task<IActionResult> GetVehiculo()
        {
            //var Vehiculo = await _ConexionBD.vehiculos.ToListAsync();

            //  RECARGAR el vehículo con la relación de usuario INCLUIDA para poner el nombre del usuario 
            var Vehiculo = await _ConexionBD.vehiculos
                .Include(v => v.usuario)
                .ToListAsync();


            if (Vehiculo == null || !Vehiculo.Any())
            {
                return NotFound("No se encontraron vehículos");
            }

            var respuesta = Vehiculo.Select(v=> new DtoVehiculoRespuesta
            {
                id = v.id,
                nombreUsuario = v.usuario.usuario,
                marca = v.marca,
                modelo = v.modelo,
                placa = v.placa,
                tipo = v.tipo,
                color = v.color,

            }).ToList();
            return Ok(respuesta);

        }


        [HttpPost]
        public async Task<IActionResult> PostVehiculo([FromBody] DtoVehiculoPost dtoVehiculoPost)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);

            }

            var llamar = new Vehiculos()
            {
                marca= dtoVehiculoPost.marca,
                modelo= dtoVehiculoPost.modelo,
                placa= dtoVehiculoPost.placa,
                tipo= dtoVehiculoPost.tipo,
                color= dtoVehiculoPost.color,
                FechaRegistro = DateTime.Now,
                id_usuario_fkVehiculo= dtoVehiculoPost.id_usuario_fkVehiculo,

            };

            _ConexionBD.Add(llamar);
            await _ConexionBD.SaveChangesAsync();

            //  RECARGAR el vehículo con la relación de usuario INCLUIDA para poner el nombre del usuario 
            var vehiculoCompleto = await _ConexionBD.vehiculos
                .Include(v => v.usuario)  // ← ¡CRÍTICO!
                .FirstOrDefaultAsync(v => v.id == llamar.id);

            var respuesta = new DtoVehiculoRespuesta
            {
                id = llamar.id,
                nombreUsuario = vehiculoCompleto.usuario.usuario,
                marca = llamar.marca,
                modelo = llamar.modelo,
                placa = llamar.placa,
                tipo = llamar.tipo,
                color = llamar.color,

            };
            return Ok(respuesta);

        }

        [HttpPut]
        public async Task<IActionResult> PutPVehiculo([FromBody] DtoVehiculoPut dtoVehiculoPut)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var LlamarVehiculo = await _ConexionBD.vehiculos.FirstOrDefaultAsync(p => p.id == dtoVehiculoPut.Id);

            if (LlamarVehiculo == null)
            {
                return NotFound("No se encontró vehiculo con ese ID para modificar");
            }

            LlamarVehiculo.placa = dtoVehiculoPut.placa;
            LlamarVehiculo.color= dtoVehiculoPut.color;
            LlamarVehiculo.modelo= dtoVehiculoPut.modelo;
            LlamarVehiculo.marca = dtoVehiculoPut.marca;


            _ConexionBD.Update(LlamarVehiculo);
            await _ConexionBD.SaveChangesAsync();
            return Ok(LlamarVehiculo);
        }

        [HttpDelete]

        public async Task<IActionResult> DeleteParqueo([FromBody] DtoVehiculoDelete dtoVehiculoDelete)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var LlamarVehiculo = await _ConexionBD.vehiculos.FirstOrDefaultAsync(p => p.id == dtoVehiculoDelete.Id);

            if (LlamarVehiculo == null)
            {
                return NotFound("No se encontró Vehiculo con ese ID para eliminar");

            }

            _ConexionBD.Remove(LlamarVehiculo);
            await _ConexionBD.SaveChangesAsync();
            return Ok();
        }
    }
}

