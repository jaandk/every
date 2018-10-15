using Every.Exceptions;

namespace Every.Utilities
{
    internal static class GrammarChecker
    {
        public const string St = "st";
        public const string Nd = "nd";
        public const string Rd = "rd";
        public const string Th = "th";

        public static void CheckGrammar(int n, string ordinal)
        {
            if (ordinal == Th && !CheckTh(n)) // 0, 4, 10-19, 20, 24, 30, 34
                throw new GrammarException(n, ordinal);

            if (ordinal == St && n % 10 != 1) // 1, 21, 31
                throw new GrammarException(n, ordinal);

            if (ordinal == Nd && n % 10 != 2) // 2, 22, 32
                throw new GrammarException(n, ordinal);

            if (ordinal == Rd && n % 10 != 3) // 3, 23, 33
                throw new GrammarException(n, ordinal);
        }

        private static bool CheckTh(int n)
        {
            if (n < 4 && n != 0)
                return false;

            var mod = n % 10;

            if ((n < 10 || n > 19) && mod < 4 && mod != 0)
                return false;

            return true;
        }
    }
}
