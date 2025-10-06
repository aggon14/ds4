Imports System

Module Program
    Public Sub Main(args() As String)

        Dim perrito As Perro = New Perro("Firulais", "Pastor Aleman", "0.40cm")
        Console.WriteLine(perrito.Comer("carne"))

        Dim perrito2 As Perro = New Perro("Max", "Labrador", "0.30cm")
        Console.WriteLine(perrito2.Comer("pollo"))

        Dim perrito3 As Perro = New Perro("Rocky", "Bulldog", "0.67cm")
        Console.WriteLine(perrito3.Comer("pescado"))
    End Sub

End Module
