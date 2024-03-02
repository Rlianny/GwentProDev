namespace GwentLibrary;

public class LeaderCard : Card
{
    public LeaderCard(string[] CardInfoArray) : base (CardInfoArray)
    {

    }
}

public class UnityCard : Card
{   
    public List<string> Row {get; private set;}
    public int Power {get; set;}
    public virtual bool Modificable {get; protected set;}
    public virtual int PossibleAppearances {get; protected set;}

    public UnityCard(string[] CardInfoArray) : base (CardInfoArray)
    {
        Row = CardInfoArray[3].Split(' ', StringSplitOptions.RemoveEmptyEntries).ToList();
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
    public List<string> Row {get; private set;}
    public ClearanceCard(string[] CardInfoArray) : base (CardInfoArray)
    {
        Row = CardInfoArray[3].Split(' ', StringSplitOptions.RemoveEmptyEntries).ToList();
    }
}

public class WeatherCard : SpecialCard
{   
    public string Row {get; private set;}
    public WeatherCard(string[] CardInfoArray) : base (CardInfoArray)
    {
        Row = CardInfoArray[3]; // posible error (el string puede tener más de un carácter)
    }
}