using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGameScore.BL.Exceptions
{
    // Custom exception for card validation failures (duplication, too many jokers)
    public class InvalidCardHandException : Exception
    {
        public InvalidCardHandException(string message) : base(message) { }
    }

    // Custom exception for parsing errors (invalid character)
    public class CardParseException : Exception
    {
        public CardParseException(string message) : base(message) { }
    }
}
