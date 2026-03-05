class Program
{
    static void Main()
    {
        ElokuvaKokoelma kokoelma = new ElokuvaKokoelma();

        kokoelma.Lisaa(new Elokuva("Inception", "Sci-Fi", 2010));
        kokoelma.Lisaa(new Elokuva("Titanic", "Draama", 1997));
        kokoelma.Lisaa(new Sarja("Breaking Bad", 2008, 5));
        kokoelma.Lisaa(new Sarja("The Office", 2005, 9));

        string tiedosto = "mediat.json";

        kokoelma.TallennaJson(tiedosto);
        System.Console.WriteLine("Tallennettu JSON-tiedostoon.\n");

        ElokuvaKokoelma luettu = new ElokuvaKokoelma();
        luettu.LueJson(tiedosto);

        System.Console.WriteLine("Luetut mediat:");
        luettu.TulostaMediat();
    }
}