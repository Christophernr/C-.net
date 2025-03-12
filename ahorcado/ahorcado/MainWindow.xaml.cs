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

namespace ahorcado
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
        //tomo la palabra del otro lado
        public string Mensaje { get; set; }

        //almaceno la letra 
        private string[] adivina;
        int conteo = 1;
        private void Cadena(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;

            string extraer = button.Content.ToString().ToUpper();
            
            string[] letra = Mensaje.ToUpper().ToCharArray().Select(c => c.ToString()).ToArray();

            
            //recogorro el array para ponerle los espacios en blanco como "_"
            if (adivina == null)
            {
                adivina = new string[letra.Length];
                for (int i = 0; i < letra.Length; i++)
                {
                    adivina[i] = "_";
                }
            }


            //miro si la letra es igual a la palabra y devuelvo true 
            bool encontrado = false;
            for (int i = 0; i < letra.Length; i++)
            {
                if (letra[i] == extraer)
                {
                    adivina[i] = extraer;
                    encontrado = true;
                    //final += adivina[i];
                }
            

            
            }

            //esto hace aparecer las lineas si no es correcta la letra que elegí
            //le suma al conteo 1, si el numero del conteo es igual al numero del tag de la linea entonces la linea aparece
            //son 9 lineas, automaticamente si el contador es 9 perdí porque ya aparecieron las 9 lineas (los 9 tags)
            if (!encontrado) 
            {
                foreach (UIElement elemento in canva.Children)
                {
                    if (elemento is Line linea && linea.Tag is not null && int.Parse(linea.Tag.ToString()) == conteo) 
                    {
                        linea.Visibility = Visibility.Visible;

                    }
                    else if (elemento is Rectangle rectangle && rectangle.Tag is not null && int.Parse(rectangle.Tag.ToString()) == conteo)
                    {
                        rectangle.Visibility = Visibility.Visible;
                    }
                }
                conteo++;
                if (9 < conteo)
                {
                    ahorcado.Visibility = Visibility.Visible;
                    lbl_palabra.Content = "Haz perdido el juego!!!!!!!";

                    
                }
            }

            string final = string.Join(" ", adivina);
            
            //si el array de adivina es igual al de letra
            if (adivina.SequenceEqual(letra))
            {
                MessageBox.Show("Haz adivinado la palabra");
                conteo = 1;
                lbl_palabra.Content = final;
            } //si encontré la letra
            else if (encontrado)
            {
                //MessageBox.Show("haz adivinado LA LETRA");
                lbl_palabra.Content = final;
            }
            else
            //si la letra es incorrecta
            {
                MessageBox.Show("Letra incorrcta");
            }
        }
    }
}