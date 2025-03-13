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

namespace piedra_papel_tijera
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

        int player1 = 0;
        int player2 = 0;
        private void eleccion(object sender, RoutedEventArgs e)
        {


            //el numero random de la maquina que tenemos que comparar 
            Random random = new Random(); //funcion del c# necesaria de llamar para sacar un numero random
            int aleatorio = random.Next(1,4); //funcion que trae el random, hay que poner el 4 porque el 3 no lo incluia 

            //asignaciones de poder
            int papel = 1;
            int piedra = 2;
            int tijeras = 3;

            //puintaje


            //tomamos el tag para comparar 
            Button button = sender as Button;
            int tag = int.Parse(button.Tag.ToString());
            string eleccionPlayer1= button.Content.ToString();

            if (tag == aleatorio)
            {
                MessageBox.Show("Empate");
                
            }
            else if (tag == papel && aleatorio == piedra || tag == piedra && aleatorio == tijeras || tag == tijeras && aleatorio == papel)
            {
                MessageBox.Show("Haz ganado!");
                player1++;
                
                
            }
            else
            {
                MessageBox.Show("Haz perdido");
                //lbl_eleccion.Content = eleccionPlayer1;
                player2++; 
                
            }


            //primera vez implementando switch

            string eleccionMaquina = aleatorio switch
            {
                1=> "Papel",
                2=>"Piedra",
                3=>"Tijeras"
            };

            
            lbl_eleccion.Content = eleccionPlayer1;
            
            lbl_puntajePLayer2.Content = player2;
            lbl_puntajePLayer1.Content = player1;


        }
    }
}
