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

namespace ahorcado
{
    /// <summary>
    /// Lógica de interacción para palabra.xaml
    /// </summary>
    public partial class palabra : Window
    {
        public palabra()
        {
            InitializeComponent();
        }
        //al darle al boton ejecuta el guardar la palabra, abrir la otra ventana y cerrar esta
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string texto= txt.Text;
            var inicio= new MainWindow();
            inicio.Mensaje = texto;

            inicio.Show();
            this.Close();
        }
    }
}
