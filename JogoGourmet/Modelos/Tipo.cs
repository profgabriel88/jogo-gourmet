


namespace JogoGourmet.Modelos
{
    public class Tipo
    {
        public string Nome { get; set; }
        public List<Tipo>? Subtipos { get; set; } = new();
        public Prato Prato { get; set; }

        /// <summary>
        /// Itera sobre os pratos de um determinado tipo perguntando se é o prato escolhido
        /// </summary>
        /// <param name="tipo"></param>
        /// <param name="ultimoPrato">Deve ser informado em caso de resposta negativa</param>
        /// <returns>Retorna verdadeiro ao final da iteração</returns>
        public void ApresentaPratos(Tipo tipo, string ultimoPrato = null)
        {
            if (tipo.Subtipos.Count > 0)
            {
                ApresentaSubtipos(tipo.Subtipos, tipo.Prato.Nome);
            }
            else
            {
                var pratoAMostra = string.IsNullOrEmpty(ultimoPrato) ? tipo.Prato.Nome : ultimoPrato;
                var resposta = Prompt.EscreveEAguardaResposta($"O prato que você pensou é {pratoAMostra}? s/n");

                switch (resposta)
                {
                    case "s":
                        Cardapio.AcerteiDeNovo();
                        break;

                    case "n":
                        var novoTipo = AprendePrato(tipo, pratoAMostra);
                        tipo.Subtipos.Add(novoTipo);
                        break;
                }
            }
        }

        /// <summary>
        /// Itera sobre os subtipos de um determinado tipo de comida
        /// </summary>
        /// <param name="subtipos"></param>
        /// <param name="ultimoPrato">Deve ser informado em caso de resposta negativa</param>
        private void ApresentaSubtipos(List<Tipo> subtipos, string ultimoPrato = null)
        {
            foreach (var subTipo in subtipos.Select((val, index) => new { val, index }))
            {
                var resposta = Prompt.EscreveEAguardaResposta($"O prato que você pensou é {subTipo.val.Nome}? s/n");

                switch (resposta)
                {
                    case "s":
                        ApresentaPratos(subTipo.val);
                        break;

                    case "n":
                        ApresentaPratos(subTipo.val, ultimoPrato);
                        break;
                }
            }
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
            Cardapio.acerto = true;
            return new Tipo
            {
                Nome = caracteristica,
                Prato = new Prato { Nome = prato }
            };
        }
    }

}

