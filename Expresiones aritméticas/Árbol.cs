using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expresiones_aritméticas
{
    class Árbol
    {
        private Nodo raíz;

        public Árbol(string ecuación)
        {
            CrearÁrbol(ecuación);
        }

        #region BOOLEANOS

        private bool EsNúmero(string dato)
        {
            if (dato == "+" || dato == "-" || dato == "*" || dato == "/")
                return false;
            else
                return true;
        }

        private bool EsNúmero(Nodo nodo)
        {
            if (nodo.dato == "+" || nodo.dato == "-" || nodo.dato == "*" || nodo.dato == "/")
                return false;
            else
                return true;
        }

        private bool QuedanSubárboles(List<Nodo> ecuación)
        {
            int subárboles = 0;
            for (int i = 0; i < ecuación.Count - 1; i++) {
                if (EsMultiplicaciónODivisión(ecuación.ElementAt(i))) {
                    if (i > 0 && EsNúmero(ecuación.ElementAt(i - 1)) || i < ecuación.Count - 1 && EsNúmero(ecuación.ElementAt(i + 1)))
                        subárboles++;
                    else if (i > 0 && EsMultiplicaciónODivisión(ecuación.ElementAt(i - 1)) && i < ecuación.Count - 1 && EsMultiplicaciónODivisión(ecuación.ElementAt(i + 1)))
                        subárboles++;
                }
            }
            return (subárboles > 0) ? true : false;
        }

        private bool EsSubárbolMult(List<Nodo> ecuación, int i)
        {
            if (EsMultiplicaciónODivisión(ecuación.ElementAt(i))) {
                if (i > 0 && EsNúmero(ecuación.ElementAt(i - 1)) || i < ecuación.Count - 1 && EsNúmero(ecuación.ElementAt(i + 1)))
                    return true;
                else if (i > 0 && EsMultiplicaciónODivisión(ecuación.ElementAt(i - 1)) && i < ecuación.Count - 1 && EsMultiplicaciónODivisión(ecuación.ElementAt(i + 1)))
                    return true;
            }
            return false;
        }

        private bool EsSubárbolSuma(List<Nodo> ecuación, int i)
        {
            if (EsSumaOResta(ecuación.ElementAt(i)) && i > 0 && i < ecuación.Count - 1)
                return true;
            else
                return false;
        }

        private bool EsSumaOResta(Nodo nodo)
        {
            return (nodo.dato == "+" || nodo.dato == "-") ? true : false;
        }

        private bool EsMultiplicaciónODivisión(Nodo nodo)
        {
            return (nodo.dato == "*" || nodo.dato == "/") ? true : false;
        }

        #endregion

        private List<Nodo> CrearLista(string cadena)
        {
            List<Nodo> ecuación = new List<Nodo>();
            string dato = "";
            while (cadena.Length > 0) {
                dato = cadena.ElementAt(0).ToString();
                cadena = cadena.Remove(0, 1);
                while (cadena.Length > 0 && EsNúmero(dato) && EsNúmero(cadena.ElementAt(0).ToString())) {
                    dato += cadena.ElementAt(0);
                    cadena = cadena.Remove(0, 1);
                }
                ecuación.Add(new Nodo(dato));
            }
            return ecuación;
        }

        private int Opera(int num1, int num2, string operador)
        {
            if (operador == "+")
                return num1 + num2;
            else if (operador == "-")
                return num1 - num2;
            else if (operador == "*")
                return num1 * num2;
            else //if(dato == "/")
                return num1 / num2;
        }

        private void CrearÁrbol(string cadena)
        {
            List<Nodo> ecuación = CrearLista(cadena);
            while (QuedanSubárboles(ecuación)) {
                for (int i = 0; i < ecuación.Count - 1; i++) {
                    if (EsSubárbolMult(ecuación, i)) {
                        Nodo left = ecuación.ElementAt(i - 1);
                        Nodo right = ecuación.ElementAt(i + 1);
                        ecuación.ElementAt(i).izquierdo = left;
                        ecuación.ElementAt(i).derecho = right;
                        ecuación.Remove(left);
                        ecuación.Remove(right);
                        break;
                    }
                }
            }
            while (ecuación.Count > 1) {
                for (int i = 0; i < ecuación.Count - 1; i++) {
                    if (EsSubárbolSuma(ecuación, i)) {
                        Nodo left = ecuación.ElementAt(i - 1);
                        Nodo right = ecuación.ElementAt(i + 1);
                        ecuación.ElementAt(i).izquierdo = left;
                        ecuación.ElementAt(i).derecho = right;
                        ecuación.Remove(left);
                        ecuación.Remove(right);
                        break;
                    }
                }
            }
            raíz = ecuación.ElementAt(0);
        }

        public int ResolverPreOrder()
        {
            Stack<Nodo> datos = PilaPreOrden(raíz, new Stack<Nodo>());
            Stack<int> resultado = new Stack<int>();
            while (datos.Count > 0) {
                string dato = datos.Pop().dato;
                if (EsNúmero(dato))
                    resultado.Push(Convert.ToInt32(dato));
                else {
                    int num1 = resultado.Pop();
                    int num2 = resultado.Pop();
                    resultado.Push(Opera(num1, num2, dato));
                }
            }
            return resultado.Pop();
        }

        public int ResolverPostOrden()
        {
            Queue<Nodo> datos = ColaPostOrden(raíz, new Queue<Nodo>());
            Stack<int> resultado = new Stack<int>();
            while (datos.Count > 0) {
                string dato = datos.Dequeue().dato;
                if (EsNúmero(dato))
                    resultado.Push(Convert.ToInt32(dato));
                else {
                    int num2 = resultado.Pop(); // Se lee al revés
                    int num1 = resultado.Pop();
                    resultado.Push(Opera(num1, num2, dato));
                }
            }
            return resultado.Pop();
        }

        #region Obtención de pila pre-orden y cola post-orden

        public string PreOrden()
        {
            Stack<Nodo> pila = PilaPreOrden(raíz, new Stack<Nodo>());
            string resultado = "";
            while (pila.Count > 0)
                resultado += pila.Pop().dato + ",";
            return resultado.Remove(resultado.Length - 1);
        }

        private Stack<Nodo> PilaPreOrden(Nodo nodo, Stack<Nodo> pila)
        {
            pila.Push(nodo);
            if (nodo.izquierdo != null)
                PilaPreOrden(nodo.izquierdo, pila);
            if (nodo.derecho != null)
                PilaPreOrden(nodo.derecho, pila);
            return pila;
        }

        public String PostOrden()
        {
            Queue<Nodo> cola = ColaPostOrden(raíz, new Queue<Nodo>());
            string resultado = "";
            while (cola.Count > 0)
                resultado += cola.Dequeue().dato + ",";
            return resultado.Remove(resultado.Length - 1);
        }

        private Queue<Nodo> ColaPostOrden(Nodo nodo, Queue<Nodo> cola)
        {
            if (nodo.izquierdo != null)
                ColaPostOrden(nodo.izquierdo, cola);
            if (nodo.derecho != null)
                ColaPostOrden(nodo.derecho, cola);
            cola.Enqueue(nodo);
            return cola;
        }

        #endregion
    }
}