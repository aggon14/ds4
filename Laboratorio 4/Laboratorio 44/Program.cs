internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Ingrese la nota del estudiante: ");
        float score = float.Parse(Console.ReadLine());

        if (score >= 7.0)
        {
            Console.WriteLine("Aprobado");
        }
        else
        {
            Console.WriteLine("Reprobado");
        }
    }
}