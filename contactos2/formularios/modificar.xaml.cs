using entidades;
using negocios.contactos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Text.RegularExpressions;
namespace formularios
{
    /// <summary>
    /// Lógica de interacción para modificar.xaml
    /// </summary>
    public partial class modificar : Window
    {
        public modificar(string id, string nombre, string numero,string correo)
        {
            InitializeComponent();

            txt_correo_importado_modificar.Text = correo;
            txt_nombre_importado_modificar.Text=nombre;
            txt_numero_importado_modificar.Text=numero;
            lbl_id_importando_modificar.Visibility = Visibility.Hidden;
            lbl_id_importando_modificar.Content= id;
        }

        private void Modificar()
        {
            int j;
            if (string.IsNullOrEmpty(txt_nombre_importado_modificar.Text))
            {
                MessageBox.Show("Digite nombre");
            } else if (string.IsNullOrEmpty(txt_correo_importado_modificar.Text))
            {
                MessageBox.Show("No ha digitado correo");
            } else if (!int.TryParse(txt_numero_importado_modificar.Text ,out j) || string.IsNullOrEmpty(txt_numero_importado_modificar.Text))
            {
                MessageBox.Show("Digite bien el numero");
            }
            else
            {
                string validar = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
                bool CorreoCorrecto = Regex.IsMatch(txt_correo_importado_modificar.Text, validar);

                if (CorreoCorrecto )
                {
                    var TraerServicio = new servicioContacto();
                    var TraerClase = new Contactos
                    {
                        nombre = txt_nombre_importado_modificar.Text,
                        numero = int.Parse(txt_numero_importado_modificar.Text),
                        correo = txt_correo_importado_modificar.Text,
                        id = int.Parse(lbl_id_importando_modificar.Content.ToString())

                    };
                    

                    var todoBien=TraerServicio.modificar(TraerClase);
                    if (todoBien)
                    {
                        MessageBox.Show("Modificado con exito");
                        salir();
                    }

                }
                else
                {
                    MessageBox.Show("No ha digitado un correo valido");
                }

                
            } 

        }

        private void salir()
        {
            int idModificar = int.Parse(lbl_id_importando_modificar.Content.ToString());
            string nameModificar = txt_nombre_importado_modificar.Text;
            string correoModificar = txt_correo_importado_modificar.Text;
            string numberModificar = txt_numero_importado_modificar.Text;
            var volver = new informacionContacto(idModificar, nameModificar, numberModificar, correoModificar);
            volver.Show();
            this.Close();
        }
        private void btn_guardarCambios_Click(object sender, RoutedEventArgs e)
        {
            Modificar();
        }

        private void btn_volver_modificar_Click(object sender, RoutedEventArgs e)
        {
            salir();

        }
    }
}
