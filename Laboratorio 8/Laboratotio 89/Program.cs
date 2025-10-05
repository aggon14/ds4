using Laboratotio_89;

internal class Program
{
    private static void Main(string[] args)
    {
        Template template = new Template();
        template.ponerVariable("var1", "valor1");
        template.ponerVariable("var2", "valor2");
        template.ponerVariable("var3", "valor3");
        template.verHtml("<br> Texto de prueba </br>");


    }
}