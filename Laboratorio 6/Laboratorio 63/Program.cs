using System;

namespace Laboratorio63
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
                Console.WriteLine("Error: Ingreso inválido.");
            }
            finally
            {
                Console.WriteLine("El bloque finally siempre se ejecuta.");
            }
        }
    }
}
