Imports System

Module Program
    Sub Main()
        Dim Radio As Single
        Dim Area As Single
        Dim Circunferencia As Single

        Console.WriteLine("Ingrese el radio")
        Radio = Console.ReadLine()

        Area = Math.PI * Radio ^ 2
        Circunferencia = 2 * Math.PI * Radio

        Console.WriteLine("El area es: {0}", Area)
        Console.WriteLine("La circunferencia es: {0}", Circunferencia)

        Console.ReadKey()
    End Sub
End Module
