public class Elokuva
{
    public string Nimi {get; set;}
    public string Genre {get; set;}
    public int Vuosi {get; set;}

    public Elokuva(string nimi, string genre, int vuosi)
    {
        Nimi = nimi;
        Genre = genre;
        Vuosi = vuosi;
    }

    public override string ToString()
    {
        return $"{Nimi};{Genre};{Vuosi}";
    }
}

public class ElokuvaKokoelma
{
    public List<Elokuva> Elokuvat {get; private set;} = new List<Elokuva>();

    public void LisaaElokuva(Elokuva elokuva)
    {
        Elokuvat.Add(elokuva);
    }

    public void TallennaTiedostoon(string polku)
    {
        using (StreamWriter writer = new StreamWriter(polku))
        {
            foreach (Elokuva i in Elokuvat)
            {
                writer.WriteLine(i.ToString());
            }
        }
    }

    public void LueTiedostosta(string polku)
    {
        Elokuvat.Clear();

        if (!File.Exists(polku))
            return;

        foreach (string rivi in File.ReadAllLines(polku))
        {
            string[] osat = rivi.Split(';');
            if (osat.Length == 3)
            {
                string nimi = osat[0];
                string genre = osat[1];
                int vuosi = int.Parse(osat[2]);

                Elokuvat.Add(new Elokuva(nimi, genre, vuosi));
            }
        }
    }

    public void TulostaElokuvat()
    {
        foreach (Elokuva e in Elokuvat)
        {
            Console.WriteLine($"{e.Nimi} ({e.Vuosi}) - {e.Genre}");
        }
    }
}
class Program
{
    static void Main()
    {
        ElokuvaKokoelma kokoelma = new ElokuvaKokoelma();

        kokoelma.LisaaElokuva(new Elokuva("Inception", "Sci-Fi", 2010));
        kokoelma.LisaaElokuva(new Elokuva("Titanic", "Draama", 1997));
        kokoelma.LisaaElokuva(new Elokuva("The Dark Knight", "Toiminta", 2008));
        kokoelma.LisaaElokuva(new Elokuva("Pulp Fiction", "Koomedia", 1994));
        kokoelma.LisaaElokuva(new Elokuva("The Matrix", "Sci-Fi", 1999));

        string tiedosto = "elokuvat.txt";
        kokoelma.TallennaTiedostoon(tiedosto);
        Console.WriteLine("Elokuvat tallennettu tiedostoon.\n");

        ElokuvaKokoelma luettuKokoelma = new ElokuvaKokoelma();
        luettuKokoelma.LueTiedostosta(tiedosto);
        Console.WriteLine("Luetut elokuvat:");
        luettuKokoelma.TulostaElokuvat();
    }
}
