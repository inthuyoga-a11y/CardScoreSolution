using CardGameScore.BL;
using CardGameScore.BL.Exceptions;
using CardGameScore.BL.StaticData;

namespace CardGameScore.Test
{
    public class CardScoreCalculatorTests
    {
        private readonly CardScoreCalculator _calculator = new CardScoreCalculator();

        [Theory]
        [InlineData(CardValue.Two, Suit.Club, 2)]
        [InlineData(CardValue.Ace, Suit.Spade, 56)]  // 14 * 4
        [InlineData(CardValue.King, Suit.Heart, 39)]  // 13 * 3
        [InlineData(CardValue.Queen, Suit.Diamond, 24)]  // 12 * 2
        [InlineData(CardValue.Joker, Suit.Joker, 0)]
        public void CalculateCardScore_ReturnsCorrectScore(CardValue value, Suit suit, int expectedScore)
        {

            var card = new Card(value, suit);
            int score = _calculator.CalculateCardScore(card);
            Assert.Equal(expectedScore, score);
        }

        [Theory]
        [InlineData("2C", "2C")]
        [InlineData("AS", "AS")]
        public void CalculateHandScore_DuplicateCards_ThrowsInvalidCardHandException(params string[] cards)
        {

            Assert.Throws<InvalidCardHandException>(() => _calculator.CalculateHandScore(cards));
        }

        [Theory]
        [InlineData("JR", "JR", "JR")]
        [InlineData("2C", "JR", "JR", "JR")]
        public void CalculateHandScore_MoreThanTwoJokers_ThrowsInvalidCardHandException(params string[] cards)
        {

            Assert.Throws<InvalidCardHandException>(() => _calculator.CalculateHandScore(cards));
        }

        [Theory]
        [InlineData(new[] { "2C", "", "3D" }, 8)]  // 2*1 + 3*2 = 8
        [InlineData(new[] { "2C", " ", "3D" }, 8)]  // 2*1 + 3*2 = 8
        public void CalculateHandScore_IgnoresEmptyOrWhitespaceCards(string[] cards, int expectedScore)
        {

            int score = _calculator.CalculateHandScore(cards);


            Assert.Equal(expectedScore, score);
        }

        //[Theory]
        //[InlineData("X5")]  // Invalid value
        //[InlineData("2X")]  // Invalid suit
        //[InlineData("2")]   // Missing suit
        //[InlineData("C")]   // Missing value
        //[InlineData("22C")] // Too long
        //[InlineData("TD")]  // Null string
        //public void CalculateHandScore_InvalidCardFormat_ThrowsCardParseException(string invalidCard)
        //{
        //    string[] cards = new[] { invalidCard };

        //    Assert.Throws<CardParseException>(() => _calculator.CalculateHandScore(cards));
        //}
    }
}