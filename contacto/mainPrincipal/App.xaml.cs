using System.Configuration;
using System.Data;
using System.Windows;
using ventanas;
namespace mainPrincipal
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App() 
        {
            ventanas.inicio venta = new ventanas.inicio();
            venta.Show();
        }
    }

}
