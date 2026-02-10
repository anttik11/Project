using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

public class ElokuvaKokoelma
{
    public List<Elokuva> Elokuvat {get; set;} = new List<Elokuva>();

    public void LisaaElokuva(Elokuva elokuva)
    {
        Elokuvat.Add(elokuva);
    }

    public void TallennaJson(string polku)
    {
        var asetukset = new JsonSerializerOptions
        {
            WriteIndented = true
        };

        string json = JsonSerializer.Serialize(Elokuvat, asetukset);
        File.WriteAllText(polku, json);
    }

    public void LueJson(string polku)
    {
        if (!File.Exists(polku))
            return;

        string json = File.ReadAllText(polku);
        Elokuvat = JsonSerializer.Deserialize<List<Elokuva>>(json);
    }

    public void TulostaElokuvat()
    {
        foreach (Elokuva i in Elokuvat)
        {
            Console.WriteLine($"{i.Nimi} ({i.Vuosi}) - {i.Genre}");
        }
    }
}