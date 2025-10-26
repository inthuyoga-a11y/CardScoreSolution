using CardGameScore.BL.Exceptions;
using CardGameScore.BL.StaticData;

namespace CardGameScore.BL
{
    public class CardStringConverter
    {
        private static readonly Dictionary<char, CardValue> valueMap = new Dictionary<char, CardValue>()
        {
            {'2',CardValue.Two },
            {'3',CardValue.Three },
            {'4',CardValue.Four },
            {'5',CardValue.Five },
            {'6',CardValue.Six },
            {'7',CardValue.Seven },
            {'8',CardValue.Eight },
            {'9',CardValue.Nine },
            {'T',CardValue.Ten },
            {'J',CardValue.Jack },
            {'Q',CardValue.Queen },
            {'K',CardValue.King },
            {'A',CardValue.Ace }
        };
        private static readonly Dictionary<char, Suit> suitMap = new Dictionary<char, Suit>()
        {
            {'C',Suit.Club },
            {'D',Suit.Diamond },
            {'H',Suit.Heart },
            {'S',Suit.Spade }
        };

        public static Card ConvertCard(string inputString)
        {
            if (string.IsNullOrWhiteSpace(inputString) || inputString.Length != 2)
            {
                // have to length 2
                throw new CardParseException(CardExceptionMessages.CardNotRecognized);
            }
            if (inputString.ToUpper() == "JR")
            {
                return new Card(CardValue.Joker, Suit.Joker);
            }

            char valueChar = char.ToUpper(inputString[0]);
            char suitChar = char.ToUpper(inputString[1]);

            if (!valueMap.TryGetValue(valueChar, out CardValue cardValue))
            {
                throw new CardParseException(CardExceptionMessages.CardNotRecognized);
            }
            if (!suitMap.TryGetValue(suitChar, out Suit suit))
            {
                throw new CardParseException(CardExceptionMessages.CardNotRecognized);
            }
            return new Card(cardValue, suit);

        }

    }
}
