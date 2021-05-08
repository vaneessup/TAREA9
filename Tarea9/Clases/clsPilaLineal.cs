using System;
using System.Collections.Generic;
using System.Text;
using Tarea9.Clases.Clases_Lista;

namespace Tarea9.Clases
{
    class clsPilaLineal
    {
        //variable ambito privado y estatic
        private static int TAMPILA = 49;//tama;o de la pila
        private int cima;//va a devolver elemeto que est[a en la cima
        private Object[] ListaPila;//tipo object para almacenar cualquier tipo de dato
        public Nodo lista;
        public clsListaEnlazada agg = new clsListaEnlazada();

        public clsPilaLineal()
        {
            cima = -1; //Condición de pila vacia.
        }
        public bool pilaLlena()
        {
            return cima == 50;
        }
        //Operaciones que modifican la pila 
        public void insertar(Object elemento)
        {
            if (pilaLlena())
            {
                throw new Exception("Desbordamiento de pila Stack Overflow");
            }
            //incrementar puntero cima y vamos a insertar el elemento
            cima++;
            //addfiles.inserta(elemento);
            agg.Inserta(elemento);

            lista = agg.cabeza;

        }

        public bool PilaVacia()
        {
            return cima == -1;
        }
        //Extraer elemento de la pila 

        //Retorna un tipo char
        public object quitarChar()
        {
            char aux;
            if (PilaVacia())
            {
                throw new Exception("Pila Vacia");
            }
            if (lista != null)
            {
                aux = (char)lista.dato;
            }
            else
            {
                aux = ' ';
                return aux;
            }
            lista = lista.enlace;
            cima--;
            return aux;
        }

        public Object quitar()
        {
            int aux;
            if (PilaVacia())
            {
                throw new Exception("La pila esta vacia");
            }
            aux = (int)lista.dato;
            agg.Delete(lista.dato);
            lista = lista.enlace;
            cima--;
            return aux;

        }
        public void limpiarPila()
        {
            cima = -1;
        }

        //operacion de acceso a la pila 

        public Object cimaPila()
        {
            if (PilaVacia())
            {
                throw new Exception("PILA VACIA");
            }
            return ListaPila[cima];//no esta desapilando, solo devolviendo el valor que esta en la cima
        }
    }
}
