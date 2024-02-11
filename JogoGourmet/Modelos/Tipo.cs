namespace JogoGourmet.Modelos
{
    public class Tipo
    {
        public string Nome { get; set; }
        public List<Tipo>? Subtipos { get; set; } = new();
        public List<Prato> Pratos { get; set; }

        /// <summary>
        /// Itera sobre os pratos de um determinado tipo perguntando se é o prato escolhido
        /// </summary>
        /// <param name="tipo"></param>
        /// <returns>Retorna verdadeiro ao final da iteração</returns>
        public bool ApresentaPratos(Tipo tipo)
        {
            var acerto = false;
            if (tipo.Subtipos.Count > 0)
            {
                foreach (var t in tipo.Subtipos.Select((val, i) => new { val, i }))
                {
                    if (acerto) break;

                    var resposta = Prompt.EscreveEAguardaResposta($"O prato que você pensou é {t.val.Nome}? s/n");

                    switch (resposta)
                    {
                        case "s":
                            acerto = ApresentaPratos(t.val);
                            break;

                        case "n":
                            if (t.i > Subtipos.Count - 1)
                            {
                                var novoTipo = AprendePrato(t.val, t.val.Pratos.First().Nome);
                                t.val.Subtipos.Add(novoTipo);
                                acerto = true;
                            }
                            ApresentaPratos(t.val);
                            break;
                    }
                }
            }
            else
            {
                foreach (var p in tipo.Pratos.Select((val, i) => new { val, i }))
                {
                    if (acerto) break;

                    var resposta = Prompt.EscreveEAguardaResposta($"O prato que você pensou é {p.val.Nome}? s/n");

                    switch (resposta)
                    {
                        case "s":
                            acerto = Cardapio.AcerteiDeNovo();
                            break;

                        case "n":
                            if (p.i >= tipo.Pratos.Count - 1)
                            {
                                var novoTipo = AprendePrato(tipo, p.val.Nome);
                                tipo.Subtipos.Add(novoTipo);
                                acerto = true;
                            }
                            break;
                    }
                }
            }
            return acerto;
        }

        /// <summary>
        /// Aprende um novo prato para um determinado tipo
        /// </summary>
        /// <param name="tipo">Tipo que receberá um novo prato</param>
        /// <param name="nome">Nome do prato para ser aprendido</param>
        /// <returns>Retorna um tipo contendo o prato</returns>
        public Tipo AprendePrato(Tipo tipo, string nome)
        {
            var prato = Prompt.EscreveEAguardaResposta("Desisto, qual prato você pensou?");
            var caracteristica = Prompt.EscreveEAguardaResposta($"{prato} é _______ mas {nome} não.");

            return new Tipo
            {
                Nome = caracteristica,
                Pratos = new List<Prato>
                {
                    new Prato
                    {
                        Nome = prato
                    }
                }
            };
        }
    }

}

