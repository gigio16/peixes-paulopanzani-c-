
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
