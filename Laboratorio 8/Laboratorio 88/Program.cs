using Laboratorio_88;

internal class Program
{
    private static void Main(string[] args)
    {
        ClaseConcretal concreta1 = new ClaseConcretal();
        concreta1.printOut();
        Console.WriteLine(concreta1.prefixValor("ES_"));

        ClaseConcreta2 concreta2 = new ClaseConcreta2();
        concreta2.printOut();
        Console.WriteLine(concreta2.prefixValor("ES_"));
    }
}