using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace generador
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }







        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int numeroMaximo=int.Parse( txt_numeroCaracteres.Text);
            string contraseñaGenerada = "";

            string[] caracteresEspeciales =["!,@,#,$,%,^,&,*,(,),_,+,-,="];

            string[] contraseña = [3.Length];

        }
    }
}