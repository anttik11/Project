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

        string tiedosto = "elokuvat.json";

        kokoelma.TallennaJson(tiedosto);
        Console.WriteLine("Elokuvat tallennettu JSON-tiedostoon\n");

        ElokuvaKokoelma luettuKokoelma = new ElokuvaKokoelma();
        luettuKokoelma.LueJson(tiedosto);

        Console.WriteLine("Luetut elokuvat:");
        luettuKokoelma.TulostaElokuvat();
    }
}
