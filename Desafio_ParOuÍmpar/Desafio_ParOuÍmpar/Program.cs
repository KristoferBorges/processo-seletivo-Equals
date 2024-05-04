using System;

public class Program
{
    public static void Centralizador(string texto)
    {
        Console.WriteLine();
        Console.WriteLine(texto.PadLeft((Console.WindowWidth + texto.Length) / 2));
        Console.WriteLine();
    }


    public static void Main(string[] args)
    {
        int numero = 0;

        Console.ForegroundColor = ConsoleColor.Yellow;
        Program.Centralizador("SISTEMA DE ANÁLISE NUMÉRICA");

        Console.Write("[ ? ] - Insira um número inteiro\n--> ");
            
        while (!int.TryParse(Console.ReadLine(), out numero))
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("[ ! ] - Por favor, insira um número válido.");
            Console.Write("[ ? ] - TENTE NOVAMENTE --> ");
        }

        Console.ForegroundColor = ConsoleColor.Yellow;
        if (numero % 2 == 0)
        {
            Console.WriteLine($"\nO número [{numero}] é PAR.");
        }
        else
        {
            Console.WriteLine($"\nO número [{numero}] é ÍMPAR.");
        }

        Console.ReadLine();
    }
}