using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using capaN;
using capaN.frutasrojas;
//using capaN.frutasrojas.servicios_frutas_rojas.cs;



namespace capaP
{
    public partial class FRM_Frutas_Rojas : Form
    {
        public FRM_Frutas_Rojas()
        {
            InitializeComponent();
        }

        private void btn_Guardar_Click(object sender, EventArgs e)
        {
            Guardar();

        }

        private void Guardar()
        {
            var nombrefruta = txtNombreRojas.Text;

            var TraerClase = new clase_frutas_rojas(0, nombrefruta); /*papi*/
            var TraerServicios = new servicios_frutas_rojas(); /*mami*/

            TraerServicios.InsertarRojas(TraerClase);



        }
    }
}
