﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace T27_API_ER_SQL_EX3.Model
{
    public class Cajero
    {
        // ATRIBUTOS, GETTERS Y SETTERS
        public int Codigo { get; set; }
        public string NomApels { get; set; }

        public ICollection<Venta> Ventas { get; set; }
        
        // CONSTRUCTOR
        public Cajero()
        {
            Ventas = new HashSet<Venta>();
        }
    }
}
