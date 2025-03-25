using System.Configuration;
using System.Data;
using System.Windows;
using ventanas;

namespace original
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()

        {
            ventanas.formularioListas venta = new ventanas.formularioListas();
            venta.Show();
        }


    }

}
