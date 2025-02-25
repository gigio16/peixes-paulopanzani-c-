//número de peixes 0
        Console.Write("Digite o número de peixes no lago (máximo 50): ");
        int numPeixes = int.Parse(Console.ReadLine());

        // para que o numero de peixes n ultrappasse 50
        if (numPeixes > 50)
        {
            Console.WriteLine("Número de peixes não pode ultrapassar 50.");
            return;
        }

        bool[] lago = new bool[50];
        Random[] random = new Random[];

        // coloca os peixes aleatoriamente no lago
        for (int i = 0; i < numPeixes; i++)
        {
            int peixes;
            do
            {
                peixes = random.Next(0, 50); // random é uma uma biblioteca que distribui numeros aleatoriamente
            }
            while (lago[pos]); // se houver peixe, tenta outra posição
            lago[peixes] = true;
        }

        //  número de jogadores
        Console.Write("Digite o número de jogadores: ");
        int numJogadores = int.Parse(Console.ReadLine());

        // tentativas por jogador
        Console.Write("Digite o número de tentativas por jogador: ");
        int tentativas = int.Parse(Console.ReadLine());

        // inicio do jogo 
        string[] jogadores = new string[numJogadores];
        int[] peixesPegos = new int[numJogadores];

        // nomes dos jogadores
        for (int i = 0; i < numJogadores; i++)
        {
            Console.Write("Digite o nome do jogador " + (i + 1) + ":");
            jogadores[i] = Console.ReadLine();
        }

        // loop de tentativas
        for (int rodada = 1; rodada <= tentativas; rodada++)
        {
            for (int j = 0; j < numJogadores; j++)
            {
                // pergunta ao jogador qual posição ele escolhe

                Console.WriteLine(jogadores[j] + ", sua vez de lançar a isca! Tentativa " + rodada + " de " + tentativas);
                Console.Write("Digite a posição do lago para lançar a isca (0-49): ");
                int posicao = int.Parse(Console.ReadLine());


                if (posicao >= 0 && posicao < 50)
                {
                    if (lago[posicao])
                    {
                        Console.WriteLine("Parabéns, " + jogadores[j] + "! Você pescou um peixe na posição " + posicao + ".");
                        peixesPegos[j]++;

                        lago[posicao] = false; // vai remove o peixe da posição
                    }
                    else
                    {
                        Console.WriteLine("Infelizmente, não havia peixe nessa posição.");
                    }


                }
                else
                {
                    Console.WriteLine("Você pescou uma bota!Tenta a sorte denovo e escolha um número entre 0 e 49.");
                    j--; // repete a vez do jogador, pois ele escolheu uma posição que nao á peixe
                }
            }
        }

        // exibe o resultado final
        int maxPeixes = 0;
        int vencedor = -1;
        bool empate = false;


        for (int i = 0; i < numJogadores; i++)
        {
            Console.WriteLine(jogadores[i] + " pescou " + peixesPegos[i] + " peixe(s).");

            if (peixesPegos[i] > maxPeixes)
            {
                maxPeixes = peixesPegos[i];
                vencedor = i;
                empate = false; 
            }
            else if (peixesPegos[i] == maxPeixes)
            {
                empate = true; 
            }
        }

        // Resultado
        if (empate)
        {
            Console.WriteLine("Houve um empate entre os jogadores!");
        }
        else if (vencedor != -1)
        {
            Console.WriteLine("O vencedor é " + jogadores[vencedor] + " com " + maxPeixes + " peixe(s)!");

        }
}

