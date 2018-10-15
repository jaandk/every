using System;

namespace Every.Exceptions
{
    public class GrammarException : Exception
    {
        public GrammarException(int n, string ordinal)
            : base($"'{n}{ordinal}' is grammatically incorrect.")
        {
        }
    }
}
