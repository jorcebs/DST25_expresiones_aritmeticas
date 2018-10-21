using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expresiones_aritméticas
{
    class Nodo
    {
        public string dato { get; private set; }
        public Nodo izquierdo;
        public Nodo derecho;

        public Nodo(string dato)
        {
            this.dato = dato;
            izquierdo = null;
            derecho = null;
        }

        public override string ToString()
        {
            return dato;
        }
    }
}
