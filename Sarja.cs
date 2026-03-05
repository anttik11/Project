public class Sarja : Media
{
    public int Kausia {get; set;}

    public Sarja() { }

    public Sarja(string nimi, int vuosi, int kausia) : base(nimi, vuosi)
    {
        Kausia = kausia;
    }

    public override string Kuvaus()
    {
        return $"{Nimi} ({Vuosi}) - Sarja - {Kausia} kautta";
    }
}