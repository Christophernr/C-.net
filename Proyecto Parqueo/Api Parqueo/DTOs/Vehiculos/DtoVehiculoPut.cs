using System.ComponentModel.DataAnnotations;

namespace Api_Parqueo.DTOs.Vehiculos
{
    public class DtoVehiculoPut
    {
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "Ingresar Placa del Vehiculo")]
        //[Index (IsUnique =true) ]
        public string placa { get; set; }

        [Required(ErrorMessage = "Ingresar Marca del vehiculo")]
        public string marca { get; set; }

        [Required(ErrorMessage = "Ingresar Modelo del vehiculo")]
        public string modelo { get; set; }

        [Required(ErrorMessage = "Ingresar color del vehiculo")]
        public string color { get; set; }

    }
}
