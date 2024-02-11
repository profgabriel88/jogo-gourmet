using JogoGourmet.Modelos;

namespace JogoGourmet
{
    public static class Program
    {
        public static void Main()
        {
            Cardapio.InicializaCardapio("Massa", "Lasanha");
            Cardapio.IniciaServico();
        }
    }
}
