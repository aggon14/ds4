﻿using System;

class Program
{
    private int[] sueldos; //Declaramos un vector

    public void Cargar()
    {
        sueldos = new int[6]; //Inicializamos el vector en 5
        for (int f = 1; f <= 5; f++)
        {
            Console.Write("Ingrese sueldo del operario " + f + ": ");
            String linea;
            linea = Console.ReadLine();
            sueldos[f] = int.Parse(linea); //Asignamos los 5 sueldos al vector
        }
    }

    public void Imprimir()
    {
        Console.Write("Los cinco sueldos de los operarios \n");
        for (int f = 1; f <= 5; f++)
        {
            Console.Write("[" + sueldos[f] + "] ");
        }
        Console.ReadKey();
    }

    static void Main(string[] args)
    {
        Program pv = new Program();
        pv.Cargar();
        pv.Imprimir();
    }
}


