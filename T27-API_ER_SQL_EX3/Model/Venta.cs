using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace T27_API_ER_SQL_EX3.Model
{
    public class Venta
    {
        // ATRIBUTOS, GETTERS Y SETTERS
        public int Cajero { get; set; }
        public int Maquina { get; set; }
        public int Producto { get; set; }

        public Cajero Cajeros { get; set; }
        public Maquina_Registradora Maquinas_Registradoras { get; set; }
        public Producto Productos { get; set; }

    }
}
