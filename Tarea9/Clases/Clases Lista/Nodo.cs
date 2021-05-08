using System;
using System.Collections.Generic;
using System.Text;

namespace Tarea9.Clases.Clases_Lista
{
    class Nodo
    {
        public Object dato;
        public Nodo enlace;


        public Nodo(Object x)
        {
            dato = x;
            enlace = null;
        }

        public Nodo(int x, Nodo n)
        {
            dato = x;
            enlace = n;
        }

        public Object getDato()
        {
            return dato;

        }

        public Nodo getEnlace()
        {
            return enlace;
        }
        public void setEnlace(Nodo enlace)
        {
            this.enlace = enlace;
        }


    }
}
