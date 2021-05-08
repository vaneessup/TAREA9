using java.lang;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using Tarea9.Clases;

namespace Tarea9.EvaluarExpresiones
{
    class clsEvaluador
    {
        
        private string exp; 
        private int cima;
        private string digito; 
        private int type; 
        private clsPilaLineal pilaChar = new clsPilaLineal();
  

        //Evaluando la expesión
        public double evaluarExp(string cadenaExp)
        {
  
            double total;
            cima = 0;
            try
            {
               exp = Regex.Replace(cadenaExp, @"\s", "");//quitando espacios
                int i = 0;
                //insertando a la lista
                do
                {
                    Char c;
                    c = exp[i++];
                    pilaChar.insertar(c);

                } while (i <= exp.Length - 1);
                Token();
                // analiza y evalua la expresion
                total = SumaResta();
            }
            catch (System.Exception err)
            {
                throw new System.Exception("La pila esta vacia, no se puede sacar" + err.Message);
            }
            return total;
        }

        // metodo para suma o resta
        private double SumaResta()
        {
            char op;
            double total1;
            double subTotal;
            total1 = MultDiv();
 
            while ((op = digito[0]) == '+' || op == '-')
            {
                
                Token();
                subTotal = MultDiv();
                switch (op)
                {
                    case '-':
                        total1 = total1 - subTotal;
                        break;

                    case '+':
                        total1 = total1 + subTotal;
                        break;
                }
            }
            return total1;
        }

        // metodo para multiplicacion y division
        private double MultDiv()
        {
            char op;
            double total2 = exponente();
            double subTotal1;
  
            while ((op = digito[0]) == '*' || op == '/')
            {
  
                Token();
                subTotal1 = exponente();
                switch (op)
                {
                    case '*':
                        total2 = total2 * subTotal1;
                        break;
                    case '/':
                        total2 /= subTotal1;
                        break;
                }
            }
            return total2;
        }

        // metodo que evalua un exponente
        private double exponente()
        {
            double tot;
            double subtot;
            double ex;
            int t;
            //Evaluamos los parentesis
            tot = evaluaParentesis();
            if (digito.Equals("^"))
            {
                Token();
                subtot = exponente();
                ex = tot;
                if (subtot == 0.0)
                {
                    tot = 1.0;
                }
                else
                {
                    for (t = (int)subtot - 1; t > 0; t--)
                    {
                        tot = tot * ex;
                    }
                }
            }
            return tot;
        }
        // metodo que procesa los parentesis
        private double evaluaParentesis()
        {
            double tot;
            if (digito.Equals("("))
            {
                Token();
                tot = SumaResta();
                if (!digito.Equals(")"))
                {
                   // err.GetError(brackets);
                }
                Token();
            }
            else
            {
                tot = this.total();
            }
            return tot;
        }

        //Metodo que obtiene el valor de un numero
        private double total()
        {
            double tot = 0.0;
            switch (type)
            {
                case 3:
                    try
                    {
                        tot = double.Parse(digito);
                    }
                    catch (NumberFormatException exception)
                    {
                        //err.GetError(syntaxError);
                        Console.WriteLine($"Error: {exception}");
                    }
                    Token();
                    break;
            }
            return tot;
        }

        private void Token()
        {
            digito = "";
            type = 0;
            Char digit = (char)pilaChar.lista.dato;
            if (cima == exp.Length)
            {
                digito = "\0";
                return;
            }
            if (op(digit))
            {
                digito += digit;
                cima++;
                type = 1;
                if (cima <= exp.Length - 1)
                {
                    pilaChar.lista = pilaChar.lista.enlace;
                    digit = (char)pilaChar.lista.dato;
                }
            }
            else if (Char.IsDigit(digit))
            {
                while (!op(digit))
                {
                    digito += digit;
                    cima++;
                    if (cima <= exp.Length - 1)
                    {
                        pilaChar.lista = pilaChar.lista.enlace;
                        digit = (char)pilaChar.lista.dato;
                    }
                    if (cima >= exp.Length)
                    {
                        break;
                    }
                }
                type = 3;
            }
            else
            { 
                Console.WriteLine("Error Caracter ingresado desconocido");
                digito = "\0";
                return;
            }
        }
        private bool op(object elemento)
        {
            if (("+-*/^()".IndexOf((char)elemento) != -1))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
