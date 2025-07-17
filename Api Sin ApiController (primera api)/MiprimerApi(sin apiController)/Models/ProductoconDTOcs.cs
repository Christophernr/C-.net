using System.ComponentModel.DataAnnotations;

namespace MiprimerApi_sin_apiController_.Models
{
    public class ProductoconDTOcs //como una base que es fake, que esto es lo que accede el usuario y no todo el contenido como en la "original"
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Nombre es necesario")] //asi no se va nada sin nombre
        [StringLength(40,ErrorMessage ="Maximo 50 caracteres")] 
        public string Nombre { get; set; }
        [Range(0.1,10000, ErrorMessage ="Precio mayor a 0")]
        public decimal Precio { get; set; }
        [Range(0.1, 10000, ErrorMessage = "Stock mayor a 0")]
        public int Stock { get; set; }

    }
}
