using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace atributosBanco
{

    public class tabla
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] //suma 1 automaticamente al id

        public int id { get; set; }
        public int cedula { get; set; }
        public string nombre { get; set; }
        public string contraseña { get; set; }
        public decimal saldo { get; set; }
    }
}