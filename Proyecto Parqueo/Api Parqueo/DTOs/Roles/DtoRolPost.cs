using System.ComponentModel.DataAnnotations;

namespace Api_Parqueo.DTOs.Roles
{
    public class DtoRolPost
    {
        [Required(ErrorMessage = "Ingrese rol")]
        [StringLength(50)]
        public string rol { get; set; }
    }
}
