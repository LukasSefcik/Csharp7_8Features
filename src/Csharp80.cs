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

        // warning
        // public int CalculateSquareOfAge(Person? p)
        // {
        //     int age = p.Age;
        //     return age * age;
        // }

        // no warning
        // public int CalculateSquareOfAge(Person? p)
        // {
        //     var result = 0;
        //     if (p != null)
        //     {
        //         result = p.Age * p.Age;
        //     }
        //     return result;
        // }

        // warning
        // public void Foo(string? bar)
        // {
        //     if (!bar.IsNullOrEmpty())
        //     {
        //         var length = bar.Length;
        //     }
        // }

        // no warning
        // public void Foo(string? bar)
        // {
        //     if (!bar.IsNullOrEmpty())
        //     {
        //         var length = bar!.Length;
        //     }
        // }

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

        // class BankAccount(int Id, string Name, decimal Balance)

        public class BankAccount : IEquatable<BankAccount>
        {
            public int Id { get; }
            public string Name { get; }
            public decimal Balance { get; }

            public BankAccount(string name, decimal balance)
            {
                Name = name;
                Balance = balance;
            }

            public bool Equals(BankAccount other)
            {
                return Equals(Name, other.Name) && Equals(Balance, other.Balance);
            }

            public override bool Equals(object other)
            {
                return (other as BankAccount)?.Equals(this) == true;
            }

            public override int GetHashCode()
            {
                return (Name.GetHashCode() * 17 + Balance.GetHashCode());
            }

            public void Deconstruct(out string name, out decimal balance)
            {
                name = Name;
                balance = Balance;
            }

            public BankAccount With(string name = Name, decimal balance = Balance) =>
                new BankAccount(name, balance);
        }

        // With – kopírovanie
        // a = p.With(Name: "Janko");
        // p = p with { Name = "Janko" };

        #endregion

        #region Extension Everything

        // Ability to use more than just extension methods.
        // Adding support for properties, static methods and much more.

        // Pôvodne
        // public static class IntExtensions
        // {
        //     public static bool Even(this int value)
        //     {
        //         return value % 2 == 0;
        //     }
        // }

        // Nové
        // public extension IntExtension extends int
        // {
        //     public bool Even => this % 2 == 0;
        // }

        #endregion
    }
}
