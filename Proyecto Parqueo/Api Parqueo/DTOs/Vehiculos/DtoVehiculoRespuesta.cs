using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api_Parqueo.DTOs.Vehiculos
{
    public class DtoVehiculoRespuesta
    {

        public int id { get; set; }


        public string nombreUsuario { get; set; }

        public string placa { get; set; }

        public string marca { get; set; }

        public string modelo { get; set; }

        public string color { get; set; }


        public string tipo { get; set; }

    }
}
