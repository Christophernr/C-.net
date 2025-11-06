using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api_Parqueo.DTOs.Usuario
{
    public class DtoUsuarioPost
    {


        [Required(ErrorMessage = "Ingrese su nombre")]
        [StringLength(50)]
        public string nombre { get; set; }

        [Required(ErrorMessage = "ingrese su correo electronico")]
        [StringLength(110)] 
        public string email { get; set; }

        [Required(ErrorMessage = "Usuario es obligatorio")]
        [StringLength(150)]
        public string usuario { get; set; }

        [NotMapped]
        [Required(ErrorMessage = "Contraseña es obligatoria")]
        [MinLength(8, ErrorMessage = "Minimo 8 digitos")]
        public string password { get; set; }


    }
}
