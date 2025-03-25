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
using servicios.procesos;
using atributos;
using conexion;
using Microsoft.IdentityModel.Tokens;

namespace ventanas
{
    /// <summary>
    /// Lógica de interacción para formularioListas.xaml
    /// </summary>
    public partial class formularioListas : Window
    {
        public formularioListas()
        {
            InitializeComponent();
            Mostrar();
        }

        private void Insertar()
        {

            if (combo_prio.SelectedItem is ComboBoxItem item && int.TryParse(item.Tag.ToString(), out int tag))
            {
                var negocio = new servicios.procesos.servicios();
                var tabla = new tabla
                {
                    tarea = txt_añadir_tarea.Text,
                    prioridad = tag,
                    fecha = DateTime.Now
                };


                if (negocio.insertar(tabla))
                {
                    MessageBox.Show("SI");
                    Mostrar();
                }
                else
                {
                    MessageBox.Show("no");
                }


            }
            else
                MessageBox.Show("No hay prioridad elegida");
        }

        private void btn_añadir_Click(object sender, RoutedEventArgs e)
        {
            Insertar();
        }

        //private List<tabla> tablas = new List<tabla>();
        private void txt_busqueda_general_TextChanged(object sender, TextChangedEventArgs e)
        {
            
            
            var texto= txt_busqueda_general.Text;
            var combo = combo_general.Text;

            if (string.IsNullOrEmpty(texto))
            {
                Mostrar();
            }
            else
            {
                var servicio = new servicios.procesos.servicios();
                var filtrado = servicio.llamar(combo, texto);
                tabla_tareas.ItemsSource= filtrado;
            }


        }

        private void check_Checked(object sender, RoutedEventArgs e)
        {
            var cmb = ordenar_tabla.Text;
            List<tabla> lis = tabla_tareas.ItemsSource as List<tabla>;
            if (string.IsNullOrEmpty(cmb))
            {
                MessageBox.Show("Seleccione tipo de orden");
            }
            else
            {   

                Func< tabla,object > ordenar= cmb switch
                {
                    "ID" => articulo => articulo.id,
                    "Tarea" => articulo => articulo.tarea,
                    "Prioridad" => articulo => articulo.prioridad,
                    "Fecha" => articulo => articulo.fecha
                };

                lis= check.IsChecked==true ? lis.OrderByDescending(ordenar).ToList() : lis.OrderBy(ordenar).ToList();

            }
            tabla_tareas.ItemsSource = null;
            tabla_tareas.ItemsSource = lis;

        }
        private void Mostrar()
        {
            var ver = new servicios.procesos.servicios();

            var lista = ver.listar();

            tabla_tareas.ItemsSource= lista;
        }
        private void tabla_tareas_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
