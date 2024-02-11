using JogoGourmet.Modelos;

namespace JogoGourmet.Modelos
{
    public static class Cardapio
    {
        public static List<Tipo> Tipos;
        private static string Bolo = "Bolo de Chocolate";

        /// <summary>
        /// Inicializa o cardápio com um Tipo de comida e um prato desse tipo
        /// Ex: Massa - Lasanha
        /// </summary>
        /// <param name="nomeTipo">O nome do tipo de comida</param>
        /// <param name="nomePrato">O nome do prato</param>
        public static void InicializaCardapio(string nomeTipo, string nomePrato)
        {
            Tipos = new List<Tipo>
            {
                new Tipo
                {
                    Nome = nomeTipo,
                    Pratos = new List<Prato>
                    {
                        new Prato
                        {
                            Nome = nomePrato,
                        }
                    }
                }
            };
        }

        /// <summary>
        /// Inicia o serviço do cardápio apresentando os tipos de comida e seus pratos
        /// </summary>
        public static void IniciaServico()
        {
            Prompt.SetForegroundColor(ConsoleColor.Green);
            while (true)
            {
                int len = Cardapio.Tipos.Count;
                bool acerto = false;
                Prompt.SetConsole("Pense em um prato que você gosta (enter)");
                for (int i = 0; i < len; i++)
                {
                    var t = Cardapio.Tipos[i];

                    if (acerto) break;

                    var resposta = Prompt.EscreveEAguardaResposta($"O prato que você pensou é {t.Nome} s/n?");

                    switch (resposta)
                    {
                        case "s":
                            acerto = t.ApresentaPratos(t);
                            break;

                        case "n":
                            if (i >= Cardapio.Tipos.Count - 1)
                                EhBolo(t);
                            break;
                    }
                }
            }
        }

        private static bool EhBolo(Tipo tipo)
        {
            var resposta = Prompt.EscreveEAguardaResposta($"O prato que você pensou é {Cardapio.Bolo}?");
            switch (resposta)
            {
                case "s":
                    AcerteiDeNovo();
                    break;

                case "n":
                    var novoTipo = tipo.AprendePrato(new Tipo(), Cardapio.Bolo);
                    Cardapio.Tipos.Add(novoTipo);
                    break;
            }
            return true;
        }

        public static bool AcerteiDeNovo()
        {
            Prompt.EscreveEAguardaResposta("Acertei de novo! (enter)");
            return true;
        }

        

    }
}
