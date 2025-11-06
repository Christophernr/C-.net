using System.ComponentModel.DataAnnotations;

namespace Api_Parqueo.DTOs.Vehiculos
{
    public class DtoVehiculoDelete
    {
        [Required]
        public int Id { get; set; }

        public string placa { get; set; }

        public string marca { get; set; }
    }
}
