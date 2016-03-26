using System;

namespace Every.Exceptions
{
    public class GrammarException : Exception
    {
        public GrammarException(string incorrect)
            : base($"'{incorrect}' is grammatically incorrect.")
        {
        }
    }
}
