using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;

namespace capaN.frutasrojas
{
    public class clase_frutas_rojas
    {
        //AQUI EMPIEZA
        private int idFrutasRojas;
        private string nameFrutasRojas;

        public clase_frutas_rojas(int idFrutasRojas, string nameFrutasRojas)
        {
            this.IdFrutasRojas = idFrutasRojas;
            this.NameFrutasRojas = nameFrutasRojas;
        }

        public int IdFrutasRojas { get => idFrutasRojas; set => idFrutasRojas = value; }
        public string NameFrutasRojas { get => nameFrutasRojas; set => nameFrutasRojas = value; }






        //AQUI TERMINA
    }
}
