

Imports System

Module Program
    Sub Main()
        Dim M As Double
        Dim G As Double
        Dim P As Double

        G = 9.8
        Console.WriteLine("Ingrese la masa del objeto")
        M = Console.ReadLine()

        P = M * G

        Console.WriteLine("El peso del objeto es: {0} N", P)
        Console.ReadKey()

    End Sub
End Module
