using System;

namespace Laboratorio62
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Ingrese un dividendo:");
                int dividendo = int.Parse(Console.ReadLine());

                Console.WriteLine("Ingrese un divisor:");
                int divisor = int.Parse(Console.ReadLine());

                int resultado = dividendo / divisor;
                Console.WriteLine($"Resultado: {resultado}");
            }
            catch (FormatException)
            {
                Console.WriteLine("Error: Debe ingresar solo números enteros.");
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("Error: No se puede dividir entre cero.");
            }
        }
    }
}
