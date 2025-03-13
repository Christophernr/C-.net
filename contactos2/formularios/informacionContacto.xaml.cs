using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using entidades;
using negocios;
using negocios.contactos;
namespace formularios
{
    /// <summary>
    /// Lógica de interacción para informacionContacto.xaml
    /// </summary>
    public partial class informacionContacto : Window
    {
        
        //recibe valores como en el juego de ahorcado que habia hecho
        public informacionContacto(int id,string nombre, string numero, string correo)
        {
            InitializeComponent();
            lbl_id_importando.Content = id;
            lbl_id_importando.Visibility=Visibility.Hidden;
            lbl_nombre_importado.Content = nombre;
            lbl_numero_importado.Content = numero;
            lbl_correo_importado.Content = correo;
        }

        private void btn_volver_Click(object sender, RoutedEventArgs e)
        {
            var cerrar = new inicio();
            cerrar.Show();
            this.Close();
        }

        private void btn_eliminar_Click(object sender, RoutedEventArgs e)
        {
            eliminar();
        }

        private void eliminar()
        {
            var TraerServicio = new servicioContacto();
            var TraerClase = new Contactos
            {
                nombre = lbl_nombre_importado.Content.ToString(),
                numero = int.Parse(lbl_numero_importado.Content.ToString()),
                correo = lbl_correo_importado.Content.ToString(),
                id = int.Parse(lbl_id_importando.Content.ToString()),
            };

            TraerServicio.Eliminar(TraerClase);



            //volver al inicio despues de eliminar
            var cerrar= new inicio();
            cerrar.Show();
            this.Close();

            
        }

        private void btn_modificar_Click(object sender, RoutedEventArgs e)
        {
            string nombremodificar = lbl_nombre_importado.Content.ToString();
            string numeromodificar = lbl_numero_importado.Content.ToString();
            string correomodificar = lbl_correo_importado.Content.ToString();
            string idmodificar = lbl_id_importando.Content.ToString();

            var abrirModificar= new modificar(idmodificar, nombremodificar, numeromodificar, correomodificar);
            abrirModificar.Show();
            this.Close();




        }

        //public informacionContacto()

        //{
        //    InitializeComponent();
        //}
    }
}
