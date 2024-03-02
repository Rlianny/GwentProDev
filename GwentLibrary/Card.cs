using System.Security.Cryptography;

namespace GwentLibrary;

public class Card
{   
    string type;
    public string Type
    {
        get {return TypeClassifier(type);}
        private set {type = value;}
    }
    public string Name {get; private set;}
    public string Faction {get; private set;}
    public string EffectDescription {get; private set;}
    protected int EffectNumber {get; private set;}
    public string CharacterDescription {get; private set;}
    public string Quote {get; private set;}

    public Card(string[] CardInfoArray)
    {
        type = CardInfoArray[0];
        Name = CardInfoArray[1];
        Faction = CardInfoArray[2];
        EffectDescription = CardInfoArray[5];
        EffectNumber = int.Parse(CardInfoArray[6]);
        CharacterDescription = CardInfoArray[7];
        Quote = CardInfoArray[8];
    }

    private static string TypeClassifier(string TipeLetter)
    {
        switch(TipeLetter)
        {
            case "L":
            return "Líder";

            case "O":
            return "Unidad Héroe";

            case "P":
            return "Unidad de Plata";

            case "A":
            return "Carta de Aumento";

            case "C":
            return "Carta de Clima";

            case "S":
            return "Señuelo";

            case "D":
            return "Carta de Despeje";

            default:
            throw new ArgumentException("La carta tiene un tipo no definido");
        }
    }
}