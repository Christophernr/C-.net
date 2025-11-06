using System.ComponentModel.DataAnnotations.Schema;

namespace Api_Parqueo.DTOs.RolesUsuario
{
    public class DtoRolesUsuarioPut
    {
        public int id_rol_usuario { get; set; }

        public int id_role_fk { get; set; }

    }
}
