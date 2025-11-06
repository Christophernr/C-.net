using System.ComponentModel.DataAnnotations.Schema;

namespace Api_Parqueo.DTOs.RolesUsuario
{
    public class DtoRolesUsuarioRespuesta
    {
        //public int id_rol_usuario { get; set; }

        //[Required(ErrorMessage ="")]
        public int id_usuario_fk { get; set; }
        public string usuario {  get; set; }
        public string rol {  get; set; }
    }
}
