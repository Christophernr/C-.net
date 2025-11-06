using Api_Parqueo.DTOs.Roles;
using mainParqueo;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace Api_Parqueo.infrastructure.command.ServicioRolesCommand
{
    public class DeleteRoles: ControllerBase
    {
        private readonly ConexionBD _conexionBD;

        public DeleteRoles(ConexionBD conexionBD)
        {
            conexionBD = _conexionBD;
        }



        public async Task<Roles> DeleteRol(int id_rol)
        {
            var rolExiste = await _conexionBD.roles.FirstOrDefaultAsync(p=>p.id == id_rol);

            if (rolExiste != null) 
            { 
                _conexionBD.Remove(rolExiste);
                _conexionBD.SaveChangesAsync();
                return rolExiste;

            }
            {
                return null;   
            }
        }
    }
}
