namespace JogoGourmet.Modelos
{
    public static class Prompt
    { 
        /// <summary>
        /// Configura a cor da fonte do console
        /// </summary>
        /// <param name="color">Cor desejada</param>
        public static void SetForegroundColor(ConsoleColor color)
        {
            Console.ForegroundColor = color;
        }

        /// <summary>
        /// Reinicia o Console
        /// </summary>
        /// <param name="resetMsg">Mensagem para ser exibida no início do programa</param>
        public static void SetConsole(string resetMsg)
        {
            Console.Clear();
            Console.WriteLine(resetMsg);
            Console.ReadLine();
        }

        /// <summary>
        /// Escreve uma linha e aguarda a resposta 
        /// </summary>
        /// <param name="linha">Mensagem a ser exibida</param>
        /// <returns></returns>
        public static string EscreveEAguardaResposta(string linha)
        {
            Console.WriteLine(linha);
            var resposta = Console.ReadLine();
            return resposta;
        }
    }
}
