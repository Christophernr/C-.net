using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api_Parqueo.DTOs.RolesUsuario
{
    public class DtoRolesUsuarioDelete
    {
        [Required]
        public int id_rol_usuario { get; set; }

        //[Required(ErrorMessage ="")]
        public int id_usuario_fk { get; set; }


        public string nombreUsuario;

        public string rol {  get; set; }
    }
}
