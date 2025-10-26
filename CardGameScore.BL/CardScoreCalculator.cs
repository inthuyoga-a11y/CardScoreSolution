using CardGameScore.BL.Exceptions;
using CardGameScore.BL.StaticData;
using System.Reflection;

namespace CardGameScore.BL
{
    public class CardScoreCalculator
    {
        //Calculate the score using one card base value and suit multiply
        public int CalculateCardScore(Card card)
        {
            if (card.cardValue == CardValue.Joker)
                return 0;

            int inputValue = card.GetCardBaseValue();

            int multiplierValue = (int)card.cardSuit;

            return inputValue * multiplierValue;
        }

        //Calculate the Final Score for full input Cards 
        public int CalculateHandScore(IEnumerable<string> cardString)
        {

            var cards = new List<Card>();
            //Cards with out joker list
            var otherCards = new HashSet<string>();
            int jokerCount = 0;


            foreach (var card in cardString.Where(s => !string.IsNullOrWhiteSpace(s)))
            {
                if (card.ToUpper() == "JR")
                {
                    jokerCount++;
                }
                else
                {
                    //Check duplicate
                    if (!otherCards.Add(card.ToUpper()))
                    {
                        throw new InvalidCardHandException(CardExceptionMessages.DuplicateCards);

                    }

                }
                cards.Add(CardStringConverter.ConvertCard(card));
            }

            if (jokerCount > 2)
            {
                throw new InvalidCardHandException(CardExceptionMessages.TooManyJokers);
            }

            long totalScore = 0;
            foreach (var card in cards)
            {
                totalScore += CalculateCardScore(card);
            }
            //one or two Jokers
            //Then the ‘< score >’ for the hand should be doubled
            if (jokerCount > 0)
            {
                // calculates 2^1=2 or 2^2=4
                long multiplier = (long)Math.Pow(2, jokerCount);
                totalScore *= multiplier;
            }

            return (int)totalScore;
        }
    }
}
