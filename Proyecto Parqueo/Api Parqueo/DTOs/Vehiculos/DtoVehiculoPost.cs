using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api_Parqueo.DTOs.Vehiculos
{
    public class DtoVehiculoPost
    {

        [Required]
        public int id_usuario_fkVehiculo { get; set; }

        [Required(ErrorMessage = "Ingresar Placa del Vehiculo")]
        //[Index (IsUnique =true) ]
        public string placa { get; set; }

        [Required(ErrorMessage = "Ingresar Marca del vehiculo")]
        public string marca { get; set; }

        [Required(ErrorMessage = "Ingresar Modelo del vehiculo")]
        public string modelo { get; set; }

        [Required(ErrorMessage = "Ingresar color del vehiculo")]
        public string color { get; set; }

        [Required(ErrorMessage = "Ingresar tipo del vehiculo (carro/motocicleta)")]
        public string tipo { get; set; }


    }
}
