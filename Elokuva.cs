public class Elokuva : Media
{
    public string Genre {get; set;}

    public Elokuva() { }

    public Elokuva(string nimi, string genre, int vuosi) : base(nimi, vuosi)
    {
        Genre = genre;
    }

    public override string Kuvaus()
    {
        return $"{Nimi} ({Vuosi}) - Elokuva - {Genre}";
    }
}