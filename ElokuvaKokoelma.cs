using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

public interface ITallennettava
{
    void TallennaJson(string polku);
    void LueJson(string polku);
}

public class ElokuvaKokoelma : ITallennettava
{
    public List<Media> Mediat {get; set;} = new List<Media>();

    public void Lisaa(Media media)
    {
        Mediat.Add(media);
    }

    // JSON tallennetaan tyyppi + kentät
    private class MediaDto
    {
        public string Tyyppi {get; set;} = "";
        public string Nimi {get; set;} = "";
        public int Vuosi {get; set;}

        // Elokuva
        public string? Genre {get; set;}

        // Sarja
        public int? Kausia {get; set;}
    }

    public void TallennaJson(string polku)
    {
        var dtoLista = new List<MediaDto>();

        foreach (var m in Mediat)
        {
            if (m is Elokuva e)
            {
                dtoLista.Add(new MediaDto
                {
                    Tyyppi = "Elokuva",
                    Nimi = e.Nimi,
                    Vuosi = e.Vuosi,
                    Genre = e.Genre
                });
            }
            else if (m is Sarja s)
            {
                dtoLista.Add(new MediaDto
                {
                    Tyyppi = "Sarja",
                    Nimi = s.Nimi,
                    Vuosi = s.Vuosi,
                    Kausia = s.Kausia
                });
            }
            else
            {
                throw new InvalidOperationException($"Tuntematon media-tyyppi: {m.GetType().Name}");
            }
        }

        var asetukset = new JsonSerializerOptions {WriteIndented = true};
        string json = JsonSerializer.Serialize(dtoLista, asetukset);
        File.WriteAllText(polku, json);
    }

    public void LueJson(string polku)
    {
        if (!File.Exists(polku))
            return;

        string json = File.ReadAllText(polku);
        var dtoLista = JsonSerializer.Deserialize<List<MediaDto>>(json) ?? new List<MediaDto>();

        Mediat = new List<Media>();

        foreach (var dto in dtoLista)
        {
            if (dto.Tyyppi == "Elokuva")
            {
                Mediat.Add(new Elokuva(dto.Nimi, dto.Genre ?? "", dto.Vuosi));
            }
            else if (dto.Tyyppi == "Sarja")
            {
                Mediat.Add(new Sarja(dto.Nimi, dto.Vuosi, dto.Kausia ?? 0));
            }
        }
    }

    public void TulostaMediat()
    {
        foreach (Media m in Mediat)
        {
            Console.WriteLine(m.Kuvaus());
        }
    }
}