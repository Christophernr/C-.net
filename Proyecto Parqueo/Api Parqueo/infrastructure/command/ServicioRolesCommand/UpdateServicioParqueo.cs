using Api_Parqueo.DTOs.Roles;
using mainParqueo;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api_Parqueo.infrastructure.command.ServicioRolesCommand
{
    public class UpdateRol: ControllerBase
    {
        private readonly ConexionBD _conexionBD;

        public UpdateRol(ConexionBD conexionBD)
        {
            conexionBD = _conexionBD;
        }

        public async Task<Roles> UpdateRoles(DtoRolPut dtoRolPut)
        {
            var llamarRol = await _conexionBD.roles.FirstOrDefaultAsync(p=> p.id == dtoRolPut.id);

            if (llamarRol == null)
            {
                return null;
            }
            {
                llamarRol.rol = dtoRolPut.rol;
                _conexionBD.Update(llamarRol);
                await _conexionBD.SaveChangesAsync();

                return llamarRol;
                
            }
        }
    }
}
