namespace JogoGourmet.Modelos
{
    public static class Cardapio
    {
        public static List<Tipo> Tipos { get; set; } = new List<Tipo>
        {
            new Tipo
            {
                Id = 1,
                Nome = "massa",
                Pratos = new List<Prato>
                {
                    new Prato
                    {
                        Id = 1,
                        Nome = "Lasanha",
                        TipoId = 1
                    }
                }
            }
        };

        public static string Bolo = "Bolo de Chocolate";
        public static string Pergunta = "O prato que você pensou é";
        public static int TipoCount = 0;
        public static int PratoCount = 0;
    }
}
