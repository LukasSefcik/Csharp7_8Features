using System;
using System.Collections.Generic;
using System.Text;

namespace Csharp_8
{
    class Csharp80
    {

        #region Default Interface Implementation

        public interface IBankAccountManager
        {
            // void PerformTransaction(decimal amount, string reason);

            // void PerformDebit(decimal amount, string reason)
            // {
            //     PerformTransaction(-1 * amount, $”Debit: { reason}”);
            // }

            // void PerformCredit(decimal amount, string reason)
            // {
            //     PerformTransaction(amount, $”Credit: { reason}”);
            // }
        }

        #endregion

        #region Billion Dollar Mistake

        // Možnosť označiť referenčný typ ako Null
        // T? nullable;
        // T  nonNullable;

        #endregion

        #region Async Enumerable

        // IAsyncEnumerable<T>
        // IAsyncEnumerator<T> : IAsyncDisposable
        //     MoveNextAsync, Current

        // Podpora yield return
        //     static async IAsyncEnumerable<int > GetNumbers() { yield return 1; }

        // Podpora await foreach
        //     foreach (await (var number in GetNumbers())

        #endregion

        #region Records

        // class BankAccount(Guid Id, string Name, decimal Balance)

        // With – kopírovanie
        // a = p.With(X: 5);
        // p = p with { X = 5 };

        #endregion

    }
}
