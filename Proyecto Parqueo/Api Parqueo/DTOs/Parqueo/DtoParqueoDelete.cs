using System.ComponentModel.DataAnnotations;

namespace Api_Parqueo.DTOs.Parqueo
{
    public class DtoParqueoDelete
    {
        [Required(ErrorMessage = "Ingresar id del parqueo a buscar")]
        public int id { get; set; }

        [Required(ErrorMessage = "Ingrese nombre de parqueo")]
        [StringLength(50)]
        public string nombre { get; set; }

    }
}
