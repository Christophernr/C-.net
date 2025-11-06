using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api_Parqueo.DTOs.Usuario
{
    public class DtoUsuarioDelete
    {

        [Required(ErrorMessage = "Usuario es obligatorio")]
        [StringLength(150)]
        public string usuario { get; set; }

    }
}
