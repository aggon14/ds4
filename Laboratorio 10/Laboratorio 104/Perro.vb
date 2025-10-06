Public Class Perro
    Public nombre As String
    Public raza As String
    Public altura As String

    Public Function Comer(carne As String) As String
        Return nombre + " " + "mide" + " " + altura + " " + "y comera" + " " + carne
    End Function

    Public Sub dormir()

    End Sub
    Public Sub ladrar()

    End Sub
    Public Function calcularCosto(costo As Double, impuestoas As Double) As Double
        Dim preciototal As Double
        preciototal = costo + (costo * impuestoas)
        Return preciototal
    End Function

    Public Sub New(nombre As String, raza As String, altura As String)
        Me.nombre = nombre
        Me.raza = raza
        Me.altura = altura
    End Sub
End Class