public abstract class Media
{
    public string Nimi {get; set;}
    public int Vuosi {get; set;}
    
    protected Media() { }
    public Media(string nimi, int vuosi)
    {
        Nimi = nimi;
        Vuosi = vuosi;
    }

    public virtual string Kuvaus()
    {
        return $"{Nimi} ({Vuosi}) - Media";
    }
}
