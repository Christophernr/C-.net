using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MiPrimerApiEF.DTOs
{
    public class tablaPOSTdto
    {
        [StringLength(20)]
        public string Name { get; set; }

        [Required(ErrorMessage = "No ha digitado descripcion")]
        [StringLength(50, ErrorMessage = "Maximo de caracteres es de 50")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Digitar precio es obligatorio")]
        [Column(TypeName = "decimal(12,2)")]
        [Range(0.1, 100000, ErrorMessage = "El precio tiene que ser mayor a 0")]
        public decimal Precio { get; set; }
    }
}
