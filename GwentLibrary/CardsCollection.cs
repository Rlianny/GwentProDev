using System.Dynamic;

namespace GwentLibrary;

public class CardsCollection
{
    public int NumberOfCards{get; private set;}
    public List<Card> Collection {get; private set;} = new(); // se inicializa el almacenamiento de respaldo para el elemento propiedad evitando que sea null
    public Dictionary<string, List<Card>> AllFactions {get; private set;} = new();

    public CardsCollection (List<string[]> CardInfoArray)
    {   
        NumberOfCards = CardInfoArray.Count;

        int count = 0;

        foreach(string[] infoArray in CardInfoArray)
        {
            Card card = TypeCreator(infoArray[0], infoArray);
            Collection.Add(card);
            System.Console.WriteLine($"{card.Name} ha entrado al campo de batalla");
            count++;

            if(!AllFactions.Keys.Contains(card.Faction)) //  si la facción no estaba como llave del diccionario la agregamos y agregamos la carta 
            {   
                List<Card> Temp = new();
                AllFactions.Add(card.Faction, Temp);
                Temp.Add(card);
            }
            else // si la facción ya estaba establecida como llave del diccionario solo añadimos la carta
            {
                AllFactions[card.Faction].Add(card);
            }
        }

        System.Console.WriteLine($"Han sido cargadas {count} cartas");

        if(NumberOfCards == count)
        System.Console.WriteLine("Todas las cartas han sido cargadas");
    }

    private static Card TypeCreator(string TipeLetter, string[] CardInfoArray)
    {
        switch(TipeLetter)
        {
            case "L":
            return new LeaderCard(CardInfoArray);

            case "O":
            return new HeroCard(CardInfoArray);

            case "P":
            return new SilverUnityCard(CardInfoArray);

            case "A":
            return new IncreaseCard(CardInfoArray);

            case "C":
            return new WeatherCard(CardInfoArray);

            case "S":
            return new HeroCard(CardInfoArray);

            case "D":
            return new ClearanceCard(CardInfoArray);

            default: throw new ArgumentException("La carta tiene un tipo no definido");
        }
    }
}