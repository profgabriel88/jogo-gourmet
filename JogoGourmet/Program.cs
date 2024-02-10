using JogoGourmet.Modelos;
using System.Linq;

string resposta = string.Empty;
bool acerto;
int len = 0;

Console.ForegroundColor = ConsoleColor.Green;

while (true)
{
    ResetConsole();
    for (int i = 0; i < len; i++)
    {
        var t = Cardapio.Tipos[i];

        if (acerto) break;

        resposta = ObtemResposta(t.Nome);

        switch (resposta)
        {
            case "s":
                ApresentaPratos(t);
                break;

            case "n":
                if (i >= Cardapio.Tipos.Count - 1)
                    EhBolo();
                break;
        }
    }
}

void ResetConsole()
{
    Console.Clear();
    Console.WriteLine("Pense em um prato que você gosta (enter)");
    Console.ReadLine();
    len = Cardapio.Tipos.Count;
    acerto = false;
    Cardapio.TipoCount = 0;
}

string ObtemResposta(string nome)
{
    Console.WriteLine("O prato que você pensou é {0}?", nome);
    Console.WriteLine("s/n");
    var r = Console.ReadLine();
    return r;
}

void EhBolo()
{
    resposta = ObtemResposta(Cardapio.Bolo);
    switch (resposta)
    {
        case "s":
            AcerteiDeNovo();
            break;

        case "n":
            AprendePrato(new Tipo(), Cardapio.Bolo);
            acerto = true;
            break;
    }
}

void AcerteiDeNovo()
{
    Console.WriteLine("Acertei de novo! (enter)");
    Console.ReadLine();
    acerto = true;
}

void ApresentaPratos(Tipo tipo)
{
    if (tipo.Subtipos.Count > 0)
    {
        foreach (var t in tipo.Subtipos.Select((val, i) => new { val, i }))
        {
            if (acerto) break;

            resposta = ObtemResposta(t.val.Nome);

            switch (resposta)
            {
                case "s":
                    ApresentaPratos(t.val);
                    break;

                case "n":
                    if (t.i > tipo.Subtipos.Count - 1)
                    {
                        AprendePrato(t.val, t.val.Pratos.First().Nome);
                        acerto = true;
                    }
                    ApresentaPratos(t.val);
                    break;
            }
        }
    }

    foreach (var p in tipo.Pratos.Select((val, i) => new { val, i }))
    {
        if (acerto) break;

        resposta = ObtemResposta(p.val.Nome);

        switch (resposta)
        {
            case "s":
                AcerteiDeNovo();
                break;

            case "n":
                if (p.i >= tipo.Pratos.Count - 1)
                {
                    AprendePrato(tipo, p.val.Nome);
                    acerto = true;
                }    
                break;
        }
    }
}

void AprendePrato(Tipo tipo, string nome)
{
    Console.WriteLine("Desisto, qual prato você pensou?");
    var prato = Console.ReadLine();
    Console.WriteLine("{0} é _______ mas {1} não.", prato, nome);
    var caracteristica = Console.ReadLine();
    if (string.IsNullOrEmpty(tipo.Nome))
    {
        Cardapio.Tipos.Add(new Tipo
        {
            Nome = caracteristica,
            Pratos = new List<Prato>
            {
                new Prato
                {
                    Nome = prato
                }
        }
        });
        return;
    }
    tipo.Subtipos.Add(new Tipo
    {
        Nome = caracteristica,
        Pratos = new List<Prato>
        {
            new Prato
            {
                Nome = prato
            }
        }
    });
}