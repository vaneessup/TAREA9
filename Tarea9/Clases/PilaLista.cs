using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tarea9.Clases
{
    class PilaLista
    {
        private int cima;
        private List<Object> listaPila;

        public PilaLista()
        {
            cima = -1;//Condicion de pila vacia
            listaPila = new List<Object>();

        }

        public void insertar(Object elemento)
        {
            cima++;
            listaPila.Add(elemento);
        }
        public Object quitar()
        {
            Object aux;
            if (pilaVacia())
            {
                throw new Exception("Pila Vacia");
            }
            aux = listaPila.ElementAt(cima);
            listaPila.RemoveAt(cima);
            cima--;
            return aux;
        }

        public Object cimaPila()
        {
            if (pilaVacia())
            {
                throw new Exception("Pila Vacia");
            }
            return listaPila.ElementAt(cima);
        }

        public bool pilaVacia()
        {
            return cima == -1;
        }
        public void LimpiarPila()
        {
            while (!pilaVacia())
            {
                quitar();
            }
        }
    }
}
