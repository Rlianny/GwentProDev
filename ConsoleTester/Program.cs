using System.Collections.ObjectModel;
using GwentLibrary;

class Program
{
    static void Main()
    {   
        string path = "../CardsCollection";

        List<string[]> infoListTester = CardsCreator.GetCardInfoList(path);

        CardsCollection cardsCollectionTester = new CardsCollection(infoListTester);

        Deck DeckDePrueba = new Deck("Rickpública", cardsCollectionTester.AllFactions);

        PlayerBattlefield playerBattlefield = new PlayerBattlefield();

        System.Console.WriteLine("_____________________________________:)"); 

        foreach(var item in DeckDePrueba.CardDeck)
        {
            System.Console.WriteLine(item.Name + " " + item.Faction);
        }
    }
}