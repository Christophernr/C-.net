using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api_Parqueo.DTOs.Parqueo
{

    public class DtoParqueoPut
    {
        [Required(ErrorMessage ="Ingresar id del parqueo a buscar")]
        public int id { get; set; }

        [Required(ErrorMessage = "Ingrese nombre de parqueo")]
        [StringLength(50)]
        public string nombre { get; set; }

        [Required(ErrorMessage = "Capacidad máxima es requerida")]
        [Range(1, 50, ErrorMessage = "COMO MAXIMO 50 CAMPOS")]
        public int capacidadMaxima { get; set; }

        [Range(1, 10, ErrorMessage = "Capacidad maxima de espacios Ley 7600")]
        public int capacidadLey7600 { get; set; }
    }

}
