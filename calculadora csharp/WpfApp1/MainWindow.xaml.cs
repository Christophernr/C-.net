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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        //string formula = "";
        int operacion = 0;
        int operacionDos = 0;
        string valor="";
        private void numros(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;

            string contenido= button.Content.ToString();

            if (txt_digitos.Text == "")
            {
                txt_digitos.Text = contenido.ToString();
            }
            else
            { 
                txt_digitos.Text += contenido.ToString();
            }

            
        }

        private void signos(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;

            string signo = btn.Content.ToString();

            if (txt_digitos.Text == "")
            {
                MessageBox.Show("Aun no ha digitado nada");

            }
            else
            {
                valor = signo;
                operacion = int.Parse(txt_digitos.Text);
                txt_digitos_contenedor.Text =$"{txt_digitos.Text} {valor} ";

                
            }
            txt_digitos.Text = "";
            //MessageBox.Show("va" + operacion);
        }

        private void igual(object sender, RoutedEventArgs e)
        {
            if (txt_digitos.Text == "")
            {
                MessageBox.Show("no ha digitado el segundo numero");

            }
            else
            {
                //int s = int.Parse(txt_digitos.Text);

                operacionDos= int.Parse(txt_digitos.Text);
                if (valor == "+")
                {


                    operacion += operacionDos;


                }
                else if (valor == "-")
                {
                    operacion -= operacionDos;
                }
                else if (valor == "*")
                {
                    operacion *= operacionDos;
                }
                else if (valor == "/")
                {
                    
                    if (operacionDos == 0)
                    {
                        MessageBox.Show("No se puede dividir entre 0");
                        return;
                    }
                    else
                    {
                        operacion /= operacionDos;
                    }
                }

                //txt_digitos.Text=operacion.ToString();
                txt_digitos_contenedor.Text= $"{txt_digitos_contenedor.Text}{txt_digitos.Text}";
                
                txt_digitos.Text=operacion.ToString();

                //MessageBox.Show("este es el signo" + valor);
                
            }
            
            
        }

        private void btn_limpiar_Click(object sender, RoutedEventArgs e)
        {
            txt_digitos.Text = "";
            txt_digitos_contenedor.Text = "";
            operacion = 0;
            operacionDos = 0;
            valor = "";
        }

        //metodo

    }
}
