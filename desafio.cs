using System;

{
    internal class Program
    {
        static void Main()
        {
            Console.WriteLine("Quantos peixinhos tem no lago? (Máximo 50)");
            int peixes = int.Parse(Console.ReadLine());

            while (peixes > 50)
            {
                Console.WriteLine("Ops, o número máximo é 50 peixes. Tente de novo: ");
                peixes = int.Parse(Console.ReadLine());
            }

            Console.WriteLine("Quantos jogadores vão pescar?");
            int qntJogadores = int.Parse(Console.ReadLine());

            string[] nomesJogadores = new string[qntJogadores];
            for (int i = 0; i < qntJogadores; i++)
            {
                Console.WriteLine($"Qual é o nome do jogador {i + 1}?");
                nomesJogadores[i] = Console.ReadLine();
            }

            Console.WriteLine("Quantas tentativas cada jogador tem para pescar?");
            int tentativas = int.Parse(Console.ReadLine());

            Peixe[] lago = new Peixe[50];
            Random random = new Random();

            for (int i = 0; i < peixes; i++)
            {
                int pos;
                do
                {
                    pos = random.Next(0, 50);
                } while (lago[pos] != null);

                lago[pos] = CriarPeixeAleatorio(random);
            }

            double[] kgsPescados = new double[qntJogadores];

            for (int t = 0; t < tentativas; t++)
            {
                for (int j = 0; j < qntJogadores; j++)
                {
                    Console.WriteLine($"{nomesJogadores[j]}, é sua vez de pescar!");
                    Console.WriteLine("Escolha uma posição do lago (0 a 49):");
                    int posicao = int.Parse(Console.ReadLine());

                    if (posicao < 0 || posicao >= 50)
                    {
                        Console.WriteLine("Ops! Posição inválida. Tente novamente.");
                        j--;
                        ;
                    }

                    if (lago[posicao] != null)
                    {
                        Peixe peixePescado = lago[posicao];
                        Console.WriteLine($"Você pescou um {peixePescado.Tipo} de {peixePescado.Peso:F2} kg!");
                        kgsPescados[j] += peixePescado.Peso;
                        lago[posicao] = null;
                    }
                    else
                    {
                        Console.WriteLine("Não tem peixe nessa posição, tente outra.");
                    }
                }
            }

            int indiceVencedor = 0;
            double maxKgs = kgsPescados[0];
            bool empate = false;

            for (int i = 1; i < qntJogadores; i++)
            {
                if (kgsPescados[i] > maxKgs)
                {
                    maxKgs = kgsPescados[i];
                    indiceVencedor = i;
                    empate = false;
                }
                else if (kgsPescados[i] == maxKgs)
                {
                    empate = true;
                }
            }

            if (empate)
                Console.WriteLine("Houve um empate! Todos são campeões!");
            else
                Console.WriteLine($"O vencedor é {nomesJogadores[indiceVencedor]} com {maxKgs:F2} kg de peixes!");

        }

        static Peixe CriarPeixeAleatorio(Random random)
        {
            var tiposPeixes = new (string Tipo, double MinPeso, double MaxPeso)[]
            {
                ("Tilápia", 1, 2),
                ("Pacu", 2, 4),
                ("Tambaqui", 3, 5)
            };

            var peixe = tiposPeixes[random.Next(tiposPeixes.Length)];
            double peso = random.NextDouble() * (peixe.MaxPeso - peixe.MinPeso) + peixe.MinPeso;

            return new Peixe(peixe.Tipo, peso);
        }

        class Peixe
        {
            public string Tipo { get; }
            public double Peso { get; }

            public Peixe(string tipo, double peso)
            {
                Tipo = tipo;
                Peso = peso;
            }
        }
    }
}
