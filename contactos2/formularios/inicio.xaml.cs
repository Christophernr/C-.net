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
using formularios;
using negocios.contactos;
using static System.Runtime.InteropServices.JavaScript.JSType;
namespace formularios
{
    /// <summary>
    /// Lógica de interacción para inicio.xaml
    /// </summary>
    public partial class inicio : Window
    {
        public inicio()
        {
            InitializeComponent();
            Mostrar();
            gridTabla.CanUserAddRows = false;
        }



        private void btn_guardar(object sender, RoutedEventArgs e)
        {
            var abrir = new añadir();
            abrir.Show();
            this.Close();
        }

        private void Mostrar()
        {
            var mostrar = new servicioContacto();

            var lista = mostrar.Obtener();

            gridTabla.ItemsSource = lista;
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }


    

        private void abrirInfoDlbclick(object sender, MouseButtonEventArgs e)
        {

            var seleccion = gridTabla.SelectedItem as Contactos;

            int id=seleccion.id;
            string nombre = seleccion.nombre;
            string numero= seleccion.numero.ToString();
            string correo = seleccion.correo;


            var abrir= new informacionContacto(id,nombre,numero,correo);
            abrir.Show();
            this.Close();


            // 
        }
    }
}
