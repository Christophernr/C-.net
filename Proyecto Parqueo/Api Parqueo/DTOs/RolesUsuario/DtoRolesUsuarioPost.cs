using Api_Parqueo.Controllers.ServicioVehiculos;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Api_Parqueo.DTOs.RolesUsuario
{
    public class DtoRolesUsuarioPost
    {


        //[Required(ErrorMessage ="")]
        public int id_usuario_fk { get; set; }


        public int id_role_fk { get; set; }

    }
}
