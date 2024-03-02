namespace GwentLibrary;

public class Tools
{
    static List<Card> RandomChoice(List<Card> cardList, int n)
    {
        List<Card> result = new();

        Random random = new Random();

        if(cardList == null || cardList.Count == 0 || n <= 0)
        {
            throw new ArgumentException
            ("Párametros de entrada no válidos");
        }

        for(int i = 0; i < n; i++)
        {
            int randomIndex = random.Next(cardList.Count);
            result.Add(cardList[randomIndex]);
        }

        return result;
    }
}