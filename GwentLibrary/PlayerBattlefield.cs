using System.Runtime.CompilerServices;

namespace GwentLibrary;

public class PlayerBattlefield
{
    public List<UnityCard> MeleeRow {get; private set;} = new();
    public List<UnityCard> RangedRow {get; private set;} = new();
    public List<UnityCard> SigeeRow {get; private set;} = new();
    public List<UnityCard>[] Battlefield {get; private set;} = new List<UnityCard>[3];
    public IncreaseCard[] IncreaseColumn {get; private set;} = new IncreaseCard[3];
    public static WeatherCard[] WeatherRow {get; private set;} = new WeatherCard[3];
    public int MeleeRowScore {get; private set;}
    public int RangedRowScore {get; private set;}
    public int SigeeRowScore {get; private set;}
    public int TotalScore {get; private set;}

    // El clima será una propiedad estática de esta clase que afecte por igual a ambos battlefield;
    // Los efectos deben modificar directamente al Battlefiel;

    public PlayerBattlefield()
    {
        Battlefield[0] = MeleeRow;
        Battlefield[1] = RangedRow;
        Battlefield[2] = SigeeRow;

        UpdateBattlefieldInfo(Battlefield);
    }

    private static int ScoreCalculator(List<UnityCard> Row)
    {   
        int score = 0;
        foreach(UnityCard card in Row)
        score += card.Power;

        return score;
    }

    private static int TotalScoreCalculator(int MeleeRowScore, int RangedRowScore, int SigeeRowScore)
    {
        int totalScore = MeleeRowScore + RangedRowScore + SigeeRowScore;

        return totalScore;
    }

    private void UpdateBattlefieldInfo(List<UnityCard>[] Battlefield)
    {
        MeleeRowScore = ScoreCalculator(Battlefield[0]);
        RangedRowScore = ScoreCalculator(Battlefield[1]);
        SigeeRowScore = ScoreCalculator(Battlefield[2]);
        TotalScoreCalculator(MeleeRowScore, RangedRowScore, SigeeRowScore);
    }

    public void AddUnityCardToMyBattlefield(UnityCard card, int n)
    {   
        if(n < 0 || n > 2)
        throw new ArgumentException("Operación inválida, no puede añadirse la carta, posición no definida");

        if(n == 0 && card.Row.Contains("M"))
        {
            Battlefield[n].Add(card);
            card.ActivateEffect();
        }

        else if(n == 1 && card.Row.Contains("R"))
        {
            Battlefield[n].Add(card);
            card.ActivateEffect();
        }

        else if(n == 2 && card.Row.Contains("S"))
        {
            Battlefield[n].Add(card);
            card.ActivateEffect();
        }

        else
        throw new ArgumentException("Operación inválida, no puede agregarse la carta, fila no definida");

        UpdateBattlefieldInfo(Battlefield);
    }

    public void AddWeatherCardToMyBattlefield(WeatherCard card)
    {
        if(card.Row == "M" && WeatherRow[0] == null)
        {
            WeatherRow[0] = card;
            card.ActivateEffect();
        }

        else if(card.Row == "R" && WeatherRow[1] == null)
        {
            WeatherRow[1] = card;
            card.ActivateEffect();
        }

        else if(card.Row == "S" && WeatherRow[2] == null)
        {
            WeatherRow[2] = card;
            card.ActivateEffect();
        }

        else
        System.Console.WriteLine("No es posible agragar la carta");
        
        UpdateBattlefieldInfo(Battlefield);
    }

    public void AddIncreaseCardToMyBattlefield(IncreaseCard card, int n)
    {
        if(n < 0 || n > 2)
        throw new ArgumentException("Operación inválida, no puede añadirse la carta, posición no definida");

        if(IncreaseColumn[n] == null)
        {
            IncreaseColumn[n] = card;
            card.ActivateEffect();
            UpdateBattlefieldInfo(Battlefield);
        }

        else
        System.Console.WriteLine("No es posible agragar la carta");
    }
}