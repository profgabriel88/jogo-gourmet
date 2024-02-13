using JogoGourmet.Modelos;

namespace JogoGourmet.Modelos
{
    public static class Cardapio
    {
        public static List<Tipo> Tipos;
        public static bool acerto = false;
        private static string Bolo = "Bolo de Chocolate";

        /// <summary>
        /// Inicializa o cardápio com um Tipo de comida e um prato desse tipo
        /// Ex: Massa - Lasanha
        /// </summary>
        /// <param name="nomeTipo">O nome do tipo de comida</param>
        /// <param name="nomePrato">O nome do prato</param>
        public static void InicializaCardapio(string nomeTipo, string nomePrato)
        {
            var prato = new Prato { Nome = nomePrato };
            var tipo = new Tipo { Nome = nomeTipo, Prato = prato };
            Tipos = [tipo];
        }

        /// <summary>
        /// Inicia o serviço do cardápio apresentando os tipos de comida e seus pratos
        /// </summary>
        public static void IniciaServico()
        {
            Prompt.SetForegroundColor(ConsoleColor.Green);
            while (true)
            {
                acerto = false; 
                int len = Tipos.Count;
                Prompt.SetConsole("Pense em um prato que você gosta (enter)");
                for (int i = 0; i < len; i++)
                {
                    var tipo = Tipos[i];

                    if (acerto) break;

                    var resposta = Prompt.EscreveEAguardaResposta($"O prato que você pensou é {tipo.Nome} s/n?");

                    if (resposta.Equals("s"))
                        tipo.ApresentaPratos(tipo);

                    else if (resposta.Equals("n"))
                        if (i >= Tipos.Count - 1)
                            EhBolo(tipo);
                }
            }
        }

        /// <summary>
        /// Encerra a partida
        /// </summary>
        public static void AcerteiDeNovo()
        {
            Prompt.EscreveEAguardaResposta("Acertei de novo! (enter)");
            acerto = true;
        }

        private static void EhBolo(Tipo tipo)
        {
            var resposta = Prompt.EscreveEAguardaResposta($"O prato que você pensou é {Bolo} s/n??");
            switch (resposta)
            {
                case "s":
                    AcerteiDeNovo();
                    break;

                case "n":
                    var novoTipo = tipo.AprendePrato(new Tipo(), Bolo);
                    Tipos.Add(novoTipo);
                    break;
            }
            acerto = true;
        }
    }
}
