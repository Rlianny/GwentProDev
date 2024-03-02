using System.Dynamic;

namespace GwentLibrary;

public static class CardsCreator
{
    public static List<string[]> GetCardInfoList (string path) // método que devuelve una lista que contine toda la información de cada carta en un array
    {
        string[] CardsInPath = Directory.EnumerateFiles(path, "*.txt").ToArray();

        List<string[]> CardInfoList = new List<string[]>();

        foreach(string cardPath in CardsInPath)
        {
            CardInfoList.Add(GetCardInfoArray(cardPath));
        }

        return CardInfoList;
    }

    private static string[] GetCardInfoArray(string cardPath) // método que splitea el string que representa el contenido de un txt
    {
        string[] CardInfo = GetCardPathContent(cardPath).Split('\n');

        return CardInfo;
    }

    private static string GetCardPathContent(string path) // método que lee el contenido de un txt y devuleve un string con dicho contenido
    {
        StreamReader reader = new StreamReader(path);
        string CardContent = reader.ReadToEnd();
        reader.Close(); 

        return CardContent;
    }
}
