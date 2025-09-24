using System;

namespace Laboratorio64
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Ingrese una edad:");
                int edad = int.Parse(Console.ReadLine());

                if (edad < 0)
                {
                    throw new ArgumentOutOfRangeException("edad", "La edad no puede ser negativa.");
                }

                Console.WriteLine($"Edad ingresada: {edad}");
            }
            catch (FormatException)
            {
                Console.WriteLine("Error: Debe ingresar un número entero.");
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine($"Excepción: {ex.Message}");
            }
        }
    }
}
