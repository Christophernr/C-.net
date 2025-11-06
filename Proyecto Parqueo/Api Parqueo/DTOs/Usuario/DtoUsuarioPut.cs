using System.ComponentModel.DataAnnotations;

namespace Api_Parqueo.DTOs.Usuario
{
    public class DtoUsuarioPut
    {
        [Required(ErrorMessage ="Digite id para modificar usuario")]
        public int Id { get; set; }
        [Required(ErrorMessage = "Ingrese su nombre")]
        [StringLength(50)]
        public string nombre { get; set; }

        [Required(ErrorMessage = "ingrese su correo electronico")]
        [StringLength(110)]
        public string email { get; set; }

        [Required(ErrorMessage = "Usuario es obligatorio")]
        [StringLength(150)]
        public string usuario { get; set; }
    }
}
