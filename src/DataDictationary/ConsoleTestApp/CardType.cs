using DataDictationaryService.Domain.SeedWork;

namespace ConsoleTestApp;

public class CardType:Enumeration
{
    public static CardType Amex = new CardType(1, "Amex");
    public static CardType Discover = new CardType(2, "Discover");
    public static CardType Mastercard = new CardType(3, "Mastercard");
    public static CardType Visa = new CardType(4, "Visa");
    
    public CardType(int id, string name) : base(id, name)
    {
    }
}