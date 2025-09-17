internal class Program
{
    private static void Main(string[] args)
    {
        int suma , cantidad, valor, promedio;
        String linea;
        suma = 0;
        cantidad = 0;
        do
        {
            Console.Write("Ingrese un valor entero (0 para terminar): ");
            linea = Console.ReadLine();
            valor = int.Parse(linea);
            if (valor != 0)
            {
                suma = suma + valor;
                cantidad++;
            }
        }while (valor != 0);
        if (cantidad != 0)
        {
            promedio = suma / cantidad;
            Console.Write("El promedio es: " + promedio);
            Console.Write(promedio);

        }
        else
        {
            Console.Write("No se ingresaron valores.");
        }
        Console.ReadKey();  

    }
}