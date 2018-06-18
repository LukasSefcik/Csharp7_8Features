using System;

namespace Csharp_8
{
    public class Csharp71
    {
        #region Async Main

        // Predtým
        // static int Main()
        // {
        //    return DoAsyncWork().GetAwaiter().GetResult();
        // }

        // Teraz
        // static async Task<int> Main()
        // {
        //     return await DoAsyncWork();
        // }

        #endregion

        #region Default Literal Expressions

        void DefaultLiteralExpressions()
        {
            // Predtým
            Func<string, bool> whereClause = default(Func<string, bool>);

            // Teraz
            Func<string, bool> whereClauseNew = default;
        }

        #endregion

        #region Inferred Tuple Element Names

        void InferredTupleElementNames()
        {
            void Predtym()
            {
                int count = 5;
                string label = "Colors used in the map";
                var pair = (count: count, label: label);

                Console.WriteLine($"{pair.count} - {pair.label}");
            }

            void Teraz()
            {
                int count = 5;
                string label = "Colors used in the map";
                var pair = (count, label);

                Console.WriteLine($"{pair.count} - {pair.label}");
            }
        }

        #endregion
    }
}
