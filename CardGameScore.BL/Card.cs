using CardGameScore.BL.StaticData;

namespace CardGameScore.BL
{
    public class Card
    {
        public CardValue cardValue { get; set; }
        public Suit cardSuit { get; set; }

        public Card(CardValue value,Suit _suit)
        {
            cardValue = value;
           cardSuit = _suit;
        }

        public int GetCardBaseValue()
        {
            if(cardValue == CardValue.Joker) 
                return 0;

            return (int)cardValue;
        }


        // Returns a string representation of the card combining its value and suit.
        //A string in format "[CardValue][cardSuit]" (e.g. "AceS" or "2H")
        public override string ToString()
        {
            return $"{cardValue}{cardSuit}";
        }
    }
}
