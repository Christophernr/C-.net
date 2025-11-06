//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.VisualBasic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net.Mail;

namespace mainParqueo
{
    public class Roles
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [Required(ErrorMessage = "Ingrese rol")]
        [StringLength(50)]
        public string rol { get; set; }


    }

    public class Parqueo
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int id { get; set; }

        [Required(ErrorMessage = "Ingrese nombre de parqueo")]
        [StringLength(50)]
        public string nombre { get; set; }

        [Required(ErrorMessage = "Capacidad máxima es requerida")]
        [Range(1, 50, ErrorMessage = "CAPACIDAD MAXIMA 50")]
        public int capacidadMaxima { get; set; }

        [Range(1,10, ErrorMessage ="Capacidad maxima de espacios Ley 7600")]
        public int capacidadLey7600 { get; set; }
     }

    public class Usuario
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id_usuario { get; set; }

        [Required(ErrorMessage = "Ingrese su nombre")]
        [StringLength(50)]
        public string nombre { get; set; }

        [Required(ErrorMessage = "ingrese su correo electronico")]
        [StringLength(110)]
        public string email { get; set; }

        
        [Required(ErrorMessage ="Usuario es obligatorio")]
        [StringLength(150)]
        public string usuario { get; set; }

        [NotMapped]
        [Required(ErrorMessage ="Contraseña es obligatoria")]
        [MinLength(8,ErrorMessage ="Minimo 8 digitos")]
        public string password { get; set; }


        //esto si se guarda en la base
        [Required]
        public string PasswordHash { get; set; } /*password+salt*/

        [Required]
        public string Salt { get; set; } /*valor unico por usuario */

        public DateTime FechaIngreso { get; set; }


    }

    public class Vehiculos
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [Required]
        public int id_usuario_fkVehiculo {  get; set; }
        [ForeignKey("id_usuario_fkVehiculo")]
        public Usuario usuario { get; set; }


        [Required(ErrorMessage ="Ingresar Placa del Vehiculo")]
        //[Index (IsUnique =true) ]
        public string placa { get; set; }

        [Required(ErrorMessage ="Ingresar Marca del vehiculo")]
        public string marca { get; set; }

        [Required(ErrorMessage ="Ingresar Modelo del vehiculo")]
        public string modelo { get; set; }

        [Required(ErrorMessage = "Ingresar color del vehiculo")]
        public string color { get; set; }

        [Required(ErrorMessage = "Ingresar tipo del vehiculo (carro/motocicleta)")]
        public string tipo { get; set; }
        [Required]
        public DateTime FechaRegistro { get; set; }
    }


    public class RolesUsuario()
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id_rol_usuario { get; set; }

        //[Required(ErrorMessage ="")]
        public int id_usuario_fk { get; set; }
        [ForeignKey("id_usuario_fk")]
        public Usuario Usuario {get; set;}


        public int id_role_fk { get; set;}
        [ForeignKey("id_role_fk")]
        public Roles roles {get; set;}

    }

    public class Spots
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id_spot { get; set; }
        [Required(ErrorMessage = "Digitar Codigo de Spot")]
        [StringLength(5)]
        public string code { get; set; }
        [Required(ErrorMessage ="Digitar tipo (carro,motocicleta o discapacitado)")]
        public string tipo { get; set; }

        //[Required(ErrorMessage ="Digitar")]
        public bool Disponible { get; set; } = true; //se pone si esta disponible o no cuando se registran o cuando salen



    }

    public class Ocupacion //es una tabla con datos pasajeros, cuando el auto sale se borra y cambia si el espacio ya esta ocupado, el historial total lo tiene logs
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        
        public int id_vehiculo_fk { get; set; }
        [ForeignKey("id_vehiculo_fk")]
        public Vehiculos Vehiculos { get; set; }

        public int id_spot_fk { get; set; }
        [ForeignKey("id_spot_fk")]
        public Spots Spots { get; set; }


        public DateTime Entrada { get; set; }



    }

    public class Logs
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [Required(ErrorMessage = "Id vehiculo necesario")]
        public int? id_vehiculo_fk { get; set; }
        [ForeignKey("id_vehiculo_fk")]
        public Vehiculos? vehiculos { get; set; }

        //este llenan los visitantes, ya que no tiene carro registrado
        public string? placa { get; set; }

        [Required(ErrorMessage ="Debe rellenar el espacio de accion")]
        public string accion {  get; set; }

        public DateTime DateTime { get; set; }
    }
}
