using System.ComponentModel.DataAnnotations;

namespace Api_Parqueo.DTOs.Roles
{
    public class DtoRolPut
    {
        [Required(ErrorMessage = "Ingrese id para eliminar")]
        public int id { get; set; }
        [Required(ErrorMessage = "Ingrese rol")]
        [StringLength(50)]
        public string rol { get; set; }
    }
}
