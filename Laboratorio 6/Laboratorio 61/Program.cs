using System;

namespace Laboratorio61
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Ingrese un número:");
                int numero = int.Parse(Console.ReadLine());
                Console.WriteLine($"Número ingresado: {numero}");
            }
            catch (FormatException)
            {
                Console.WriteLine("Error: El valor ingresado no es un número válido.");
            }
        }
    }
}
