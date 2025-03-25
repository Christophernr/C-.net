using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace atributos
{
    public class tabla
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] //suma1

        public int id { get; set; }
        [Required]
        public string tarea { get; set; }
        [Required]
        public int prioridad { get; set; }

        public DateTime fecha { get; set; }


    }
}
