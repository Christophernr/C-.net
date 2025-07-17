namespace MiprimerApi_sin_apiController_.Models
{
    public class Producto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public int Stock { get; set; }
        public DateTime fechaCreacion { get; set; }

        public bool UsuarioActivo { get; set; }
    }
}
