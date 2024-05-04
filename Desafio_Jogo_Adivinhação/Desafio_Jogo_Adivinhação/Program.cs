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
        int tentativas = 1;

        // Definição de cores para o terminal
        Console.ForegroundColor = ConsoleColor.Yellow;

        Random random = new Random();
        int numero = random.Next(1, 101);

        Centralizador("BEM-VINDO(a) AO JOGO DE ADIVINHAÇÃO");
        Console.Write("[ ! ] - PENSEI EM UM NÚMERO ENTRE 1 E 100, QUAL SERIA?\n--> ");

        int escolha;
        while (!int.TryParse(Console.ReadLine(), out escolha))
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("[ ! ] - Por favor, insira um número válido.");
            Console.Write("[ ? ] - TENTE NOVAMENTE --> ");
        }

        while (true)
        {
            if (escolha == 0)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("[ ! ] - O JOGO FOI ENCERRADO!");
                break;
            }
            if (escolha == numero)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Centralizador("PARABÉNS, VOCÊ ACERTOU!");
                Console.WriteLine($"VOCÊ ACERTOU COM [{tentativas}] TENTATIVAS");
                break;
            }
            else
            {
                if (escolha < numero)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Centralizador("[ ! ] - O NÚMERO É MAIOR!");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Centralizador("[ ! ] - O NÚMERO É MENOR!");
                }

                tentativas++;
            }
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("[ ? ] - TENTE NOVAMENTE --> ");

            while (!int.TryParse(Console.ReadLine(), out escolha))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("[ ! ] - Por favor, insira um número válido.");
                Console.Write("[ ? ] - TENTE NOVAMENTE --> ");
            }
        }

        Console.ReadLine();
    }
}