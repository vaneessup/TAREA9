using System;
using System.Collections.Generic;
using System.Text;

namespace Tarea9.Clases.Clases_Lista
{
    class clsListaEnlazada
    {
        public Nodo cabeza;
        public Nodo cola;
        public Nodo actual, anterior;
        public bool encontrado;

        public clsListaEnlazada()
        {
            cabeza = null;
            cola = null;

        }

        //insertar
        public clsListaEnlazada Inserta(Object inicio)
        {
            Nodo nuevo;
            nuevo = new Nodo(inicio);

            if(cabeza == null)
            {
                cabeza = nuevo;
                cabeza.enlace = null;
                cola = nuevo;
            }
            else
            {
                cola.enlace = nuevo;
                nuevo.enlace = null;
                cola = nuevo;
            }
            return this;
        }

        //eliminar
        public void Delete(Object inicio)
        {
            actual = cabeza;
            anterior = null;
            encontrado = false;

            while((actual != null) && !encontrado)
            {
                if (!encontrado)
                {
                    anterior = actual;
                    actual = actual.enlace;
                }
                else
                {
                    Console.WriteLine("ERROR");

                }
                if(actual != null)
                {
                    if(actual == cabeza)
                    {
                        cabeza = actual.enlace;
                    }
                    else
                    {
                        anterior.enlace = actual.enlace;
                      
                    }
                }
            }
        }


    }
}
