namespace Api_Parqueo.DTOs.Usuario
{
    public class DtoUsuarioRespuesta
    {
        public int Id { get; set; }
        public string Usuario { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
        public DateTime FechaRegistro { get; set; }
        public string Mensaje { get; set; } = "Usuario creado exitosamente";
    }
}
