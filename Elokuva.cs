public class Elokuva
{
    public string Nimi {get; set;}
    public string Genre {get; set;}
    public int Vuosi {get; set;}

    public Elokuva() { } // JSON:ia varten

    public Elokuva(string nimi, string genre, int vuosi)
    {
        Nimi = nimi;
        Genre = genre;
        Vuosi = vuosi;
    }
}