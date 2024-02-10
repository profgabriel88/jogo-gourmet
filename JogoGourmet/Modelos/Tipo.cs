namespace JogoGourmet.Modelos
{
   public class Tipo
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public List<Tipo>? Subtipos { get; set; } = new();
        public List<Prato> Pratos { get; set; }
    }
}
