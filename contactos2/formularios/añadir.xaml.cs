using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
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
using Microsoft.Identity.Client;
using negocios;
using System.Text.RegularExpressions;
using negocios.contactos;
namespace formularios
{
    /// <summary>
    /// Lógica de interacción para añadir.xaml
    /// </summary>
    public partial class añadir : Window
    {
        public añadir()
        {
            InitializeComponent();
        }
        
        private void Guardar()
        {
            int j;
            int i;

            
            if (string.IsNullOrEmpty(txt_nombre.Text))
            {
                MessageBox.Show("No ha digitado nombre");
            }
            else if (string.IsNullOrEmpty(txt_correo.Text))
            {

                MessageBox.Show("No ha digitado correo correctamente");
            }
            else if (string.IsNullOrEmpty(txt_numero.Text) || !int.TryParse(txt_numero.Text, out i))
            {
                MessageBox.Show("Digite bien el numero telefonico");
            }
            else
            {
                string validar = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
                bool CorreoCorrecto = Regex.IsMatch(txt_correo.Text, validar);
                if (CorreoCorrecto)
                {
                    var TraerServicio = new servicioContacto();
                    var TraerClase = new Contactos
                    {
                        nombre = txt_nombre.Text,
                        numero = int.Parse(txt_numero.Text),
                        correo = txt_correo.Text,

                    };

                    var resultado = TraerServicio.insertar(TraerClase);

                    if (resultado)
                    {
                        MessageBox.Show("Guardado con exito");
                        Salir();

                    }
                    else
                        MessageBox.Show("Erol");

                }
                else
                {
                    MessageBox.Show("DIigitar correo valido");
                }
               
            }

        }
        private void Salir()
        {
            var cerrar = new inicio();
            cerrar.Show();
            this.Close();
        }
        private void btn_guardar_Click(object sender, RoutedEventArgs e)
        {
            Guardar();
        }

        private void btn_cancelar_Click(object sender, RoutedEventArgs e)
        {
            Salir();
        }
    }
}
