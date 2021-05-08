using System;
using System.Text;
using System.Text.RegularExpressions;
using Tarea9.Clases;
using Tarea9.Clases.Palindromo;
using Tarea9.EvaluarExpresiones;

namespace Tarea9
{
    class Program
    {
        static void ejemploPilaLineal()
        {
           clsPilaLineal pila;
            int x;
            int clave = -1;

            Console.WriteLine("Ingrese numeros y para terminar -1");

            try
            {
                pila = new clsPilaLineal();//instanciando pila
                do
                {
                    x = Convert.ToInt32(Console.ReadLine());

                    if(x != -1)
                    {
                        pila.insertar(x);
                    }
                    
                } while (x != clave);

                Console.WriteLine("Estos son los elementos de la pila: \n");

                //desapilar
                while (!pila.PilaVacia())
                {
                    x = (int)(pila.quitar());
                    Console.WriteLine($"Elemento: {x}");
                }
            }
            catch(Exception error)
            {
                Console.WriteLine("Error =" + error.Message);
            }

        }

        static void evaluar()
        {
            string ex;
            clsEvaluador eq = new clsEvaluador();
            Console.Write("INGRESE UNA ECUACION \n");
            ex = Console.ReadLine();
            try
            {
                Console.WriteLine("TOTAL: " + eq.evaluarExp(ex));
            }
            catch (Exception error)
            {
                Console.WriteLine(error);
            }
        }

        static void EjemploPilaLista()
        {
            PilaLista pl = new PilaLista();
            pl.insertar(3);
            pl.insertar(4);
            pl.insertar(8);
            pl.insertar(2);
            pl.insertar(1);

            var xx = pl.quitar();
        }
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");
            //ejemploPilaLineal();
            //clspalindromo pali = new clspalindromo();
            //pali.palindromo();
            evaluar();

        }
    }
}
