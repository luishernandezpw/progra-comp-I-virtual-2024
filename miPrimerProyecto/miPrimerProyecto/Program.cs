﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;

namespace miPrimerProyecto {
    internal class Program {
        static void Main(string[] args) {
            String continuar = "s";
            while (continuar == "s") {
                //calculadora basica.
                Console.WriteLine("Calculadora Basica");
                Console.WriteLine("1. Suma");
                Console.WriteLine("2. Resta");
                Console.WriteLine("3. Multiplicacion");
                Console.WriteLine("4. Division");
                Console.WriteLine("5. Salir");
                Console.Write("Opcion: ");
                int opcion = int.Parse(Console.ReadLine());

                if (opcion == 5) {
                    continuar = "n";
                } else {
                    Console.Write("Num 1: ");
                    double num1 = double.Parse(Console.ReadLine());

                    Console.Write("Num 2: ");
                    double num2 = double.Parse(Console.ReadLine());

                    double respuesta = 0;
                    String operacion = "";

                    if (opcion == 1) {
                        respuesta = num1 + num2;
                        operacion = "suma";
                    } else if (opcion == 2) {
                        respuesta = num1 - num2;
                        operacion = "resta";
                    } else if (opcion == 3) {
                        respuesta = num1 * num2;
                        operacion = "multiplicacion";
                    } else if (opcion == 4) {
                        respuesta = num1 / num2;
                        operacion = "division";
                    }
                    Console.WriteLine("La {0} es igual a: {1}", operacion, respuesta);
                }
            }
        }
    }
}