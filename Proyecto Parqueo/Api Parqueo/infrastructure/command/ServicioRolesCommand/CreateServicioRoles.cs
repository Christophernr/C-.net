//using Api_Parqueo.Controllers.ServicioRoles;
using Api_Parqueo.DTOs.Roles;
using mainParqueo;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;





namespace Api_Parqueo.infrastructure.command.ServicioRolesCommand
{
    public class CreateServicioRoles:ControllerBase
    {
        //instancia de siempre
        private readonly ConexionBD _conexionBD;
        public CreateServicioRoles(ConexionBD conexionBD)
        {
            conexionBD = _conexionBD;
        }


        public async Task<Roles> CreateRol(DtoRolPost dtoRolPost)
        {

            var llamar = new Roles()
            {
                rol = dtoRolPost.rol


            };

            _conexionBD.Add(llamar);
            await _conexionBD.SaveChangesAsync();
            return llamar;


    }   }
}
