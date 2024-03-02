namespace GwentLibrary;

public class LeaderCard : Card
{
    public LeaderCard(string[] CardInfoArray) : base (CardInfoArray)
    {

    }
}

public class UnityCard : Card
{   
    public string[] Fila {get; private set;}
    public int Power {get; set;}
    public virtual bool Modificable {get; protected set;}
    public virtual int PossibleAppearances {get; protected set;}

    public UnityCard(string[] CardInfoArray) : base (CardInfoArray)
    {
        Fila = CardInfoArray[3].Split(' ', StringSplitOptions.RemoveEmptyEntries);
        Power = int.Parse(CardInfoArray[4]);
    }
}

public class HeroCard : UnityCard
{  
    public HeroCard(string[] CardInfoArray) : base (CardInfoArray)
    {
        Modificable = false;
        PossibleAppearances = 1;
    }
}

public class SilverUnityCard : UnityCard
{   
    public int Appearances {get; set;}
    public SilverUnityCard(string[] CardInfoArray) : base (CardInfoArray)
    {
        Modificable = true;
        PossibleAppearances = 3;
        Appearances = 1;
    }
}

public class SpecialCard : Card
{
    public SpecialCard(string[] CardInfoArray) : base (CardInfoArray)
    {

    }
}

public class IncreaseCard : SpecialCard
{
    public IncreaseCard(string[] CardInfoArray) : base (CardInfoArray)
    {

    }
}

public class ClearanceCard : SpecialCard
{
    public ClearanceCard(string[] CardInfoArray) : base (CardInfoArray)
    {

    }
}

public class WeatherCard : SpecialCard
{
    public WeatherCard(string[] CardInfoArray) : base (CardInfoArray)
    {

    }
}