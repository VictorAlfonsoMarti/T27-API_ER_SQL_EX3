using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace T27_API_ER_SQL_EX3.Model
{
    public class Maquina_Registradora
    {
        // ATRIBUTOS, GETTERS Y SETTERS
        public int Codigo { get; set; }
        public int Piso { get; set; }

        public ICollection<Venta> Ventas { get; set; }

        // CONTRUCTOR
        public Maquina_Registradora()
        {
            Ventas = new HashSet<Venta>();
        }

    }
}
