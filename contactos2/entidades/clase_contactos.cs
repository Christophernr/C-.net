
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace entidades
{

    public class Contactos
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] //suma 1

        public int id { get; set; }
        public string nombre { get; set; }
        public int numero { get; set; }


        public string correo { get; set; }
    };
    
    
}
