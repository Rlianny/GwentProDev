using System.Collections.ObjectModel;
using GwentLibrary;

class Program
{
    static void Main()
    {   
        string path = "../CardsCollection";

        List<string[]> AlmostCards = CardsCreator.GetCardInfoList(path);

        CardsCollection AllCards = new CardsCollection(AlmostCards);

        Card[] AllCardsArray =  AllCards.AllFactions["Rickpública"].ToArray();

        Card cartadepruebasi = AllCardsArray[3];

        Card cartadepruebano = AllCardsArray[1];

        Deck DeckDePrueba = new Deck("Rickpública",AllCards.AllFactions);

        System.Console.WriteLine("_____________________________________:)"); 
    }
}