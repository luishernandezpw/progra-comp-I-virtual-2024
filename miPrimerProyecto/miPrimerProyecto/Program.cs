using System;
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
                Console.WriteLine("\n Calculadora Basica");
                Console.WriteLine("1. Suma");
                Console.WriteLine("2. Resta");
                Console.WriteLine("3. Multiplicacion");
                Console.WriteLine("4. Division");
                Console.WriteLine("5. Exponeciacion");
                Console.WriteLine("6. Raiz");
                Console.WriteLine("7. Factorial");
                Console.WriteLine("8. Salir");
                Console.Write("Opcion: ");
                int opcion = int.Parse(Console.ReadLine());

                Console.Clear();

                if (opcion == 8) {
                    continuar = "n";
                } else {
                    Console.Write("Num 1: ");
                    double num1 = double.Parse(Console.ReadLine());
                    double num2 = 0;

                    if (opcion != 7) {
                        Console.Write("Num 2: ");
                        num2 = double.Parse(Console.ReadLine());
                    }
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
                    } else if (opcion == 5) {
                        respuesta = Math.Pow(num1, num2);
                        operacion = "exponeciacion";
                    } else if (opcion == 6) {
                        respuesta = Math.Pow(num1, 1/num2);// raiz 2 de 16 = 16^(1/2)=4
                        operacion = "raiz "+ num2;
                    }else if (opcion == 7) {
                        //5! = 5*4*3*2= 120
                        respuesta = 1;
                        for (int i = 2; i <= num1; i++) {
                            respuesta *= i; //factorial = factorial * i;
                        }
                        operacion = "factorial";
                    }
                    Console.WriteLine("La {0} es igual a: {1}", operacion, respuesta);
                }
            }
        }
    }
}