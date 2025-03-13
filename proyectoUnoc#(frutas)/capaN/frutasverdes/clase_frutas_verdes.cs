using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace capaN.frutasverdes
{
    public class clase_frutas_verdes
    {
        //AQUI EMPIEZA

        private int idFrutasVerdes;
        private string nameFrutasVerdes;
        private float precio;

        public clase_frutas_verdes(int idFrutasVerdes, string nameFrutasVerdes, float precio)
        {
            this.IdFrutasVerdes = idFrutasVerdes;
            this.NameFrutasVerdes = nameFrutasVerdes;
            this.Precio = precio;
        }

        public int IdFrutasVerdes { get => idFrutasVerdes; set => idFrutasVerdes = value; }
        public string NameFrutasVerdes { get => nameFrutasVerdes; set => nameFrutasVerdes = value; }
        public float Precio { get => precio; set => precio = value; }
    }
}
