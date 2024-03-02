using System.Reflection;

namespace GwentLibrary;

public class Deck
{   

    public string Faction {get; private set;} = String.Empty; // se inicializa el almacenamiento de respaldo para el elemento propiedad evitando que sea null
    public List <Card> CardDeck {get;private set;} = new(); // se inicializa el almacenamiento de respaldo para el elemento propiedad evitando que sea null
    public int CardsTotalNumber {get; private set;}
    public int UnityCardsTotalNumber{get;private set;}
    public int HeroCardsTotalNumber {get; private set;}
    public int SpecialCardsTotalNumber {get; private set;}
    public int UnityPowerTotalNumber {get; private set;}

    public Deck(string factionName, Dictionary<string, List<Card>> factionCards)
    {
        Faction = factionName;
        CardDeck = factionCards[Faction];

        CardsTotalNumber = CardDeck.Count;
        UnityCardsTotalNumber = UnityCardsCounter(CardDeck);
        HeroCardsTotalNumber = HeroCardsCounter(CardDeck);
        SpecialCardsTotalNumber = SpecialCardsCounter(CardDeck);
        UnityPowerTotalNumber = TotalPowerCounter(CardDeck);
    }

    public void DuplicateCard(List<Card> CardDeck, Card card)
    {
        if(card is SilverUnityCard silverCard)
        {
            if(silverCard.Appearances < silverCard.PossibleAppearances)
            {
                CardDeck.Add(silverCard);
                silverCard.Appearances++;
                UpdateDeckInfo(CardDeck);
            }

            else
            System.Console.WriteLine("No es posible agregar más cartas");
        }

        else
        System.Console.WriteLine("Esta carta no es duplicable");
    }

    public void AddCardToMyDeck(List<Card> CardDeck, Card card)
    {   
        if(card.Faction == Faction || card.Faction == "Neutral")
        {
            CardDeck.Add(card);
            UpdateDeckInfo(CardDeck);
        }

        else
        Console.WriteLine("Error, no puede añadirse la carta");
    }

    public void RemoveCardToMyDeck(List<Card> CardDeck, Card card)
    {
        CardDeck.Remove(card);
        UpdateDeckInfo(CardDeck);
    }

    private void UpdateDeckInfo(List<Card> CardDeck)
    {
        CardsTotalNumber = CardDeck.Count;
        UnityCardsTotalNumber = UnityCardsCounter(CardDeck);
        HeroCardsTotalNumber = HeroCardsCounter(CardDeck);
        SpecialCardsTotalNumber = SpecialCardsCounter(CardDeck);
        UnityPowerTotalNumber = TotalPowerCounter(CardDeck);

    }

    private int UnityCardsCounter(List<Card> CardDeck)
    {
        int count = 0;
        foreach(Card card in CardDeck)
        {   
            if(card is UnityCard)
            count++;
        }

        return count;
    }

    private int HeroCardsCounter(List<Card> CardDeck)
    {
        int count = 0;
        foreach(Card card in CardDeck)
        {   
            if(card is HeroCard)
            count++;
        }

        return count;
    }

    private int SpecialCardsCounter(List<Card> CardDeck)
    {
        int count = 0;
        foreach(Card card in CardDeck)
        {   
            if(card is SpecialCard)
            count++;
        }

        return count;
    }

    private int TotalPowerCounter(List<Card> CardDeck)
    {
        int power = 0;
        foreach(Card card in CardDeck)
        {
            if(card is UnityCard unityCard) 
            power += unityCard.Power;
        }

        return power;
    }
}