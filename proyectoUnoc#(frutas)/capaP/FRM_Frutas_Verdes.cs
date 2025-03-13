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
using capaN.frutasverdes;

namespace capaP
{
    public partial class FRM_Frutas_Verdes : Form
    {
        public FRM_Frutas_Verdes()
        {
            InitializeComponent();
        }

        private void btn_GuardarVerdes_Click(object sender, EventArgs e)
        {
            Guardar();
        }

        private void Guardar()
        { 
            var txtNombreVerde= txtFrutasVerdes.Text;
            var precio=float.Parse(txtPrecio.Text) ;

            var TraerServicioVerdes= new servicio_frutas_verdes();
            var TraerClaseVerde = new clase_frutas_verdes(0, txtNombreVerde, precio);

            TraerServicioVerdes.InsertarVerdes(TraerClaseVerde);

        }
    }
}
