using System;
using System.Collections.Concurrent;
using System.Threading.Tasks;

namespace Csharp_8
{
    public class Csharp70
    {
        #region Out Vars

        public void OutVars()
        {
            Out(out int a);
            Console.WriteLine($"after the invocation of {nameof(Out)}, {nameof(a)} = {a}");

            TryParse();
        }

        void Out(out int x)
        {
            x = 2;
        }

        void TryParse()
        {
            if (int.TryParse("42", out int result))
            {
                Console.WriteLine($"the result is {result}");
            }
        }

        #endregion

        #region Pattern Matching

        public void PatternMatching()
        {
            object[] data = { null, 42, new Person("Janko Hrasko"), new Person("Matko Kubko") };

            foreach (var item in data)
            {
                IsPattern(item);
            }
        }

        void IsPattern(object o)
        {
            // const pattern
            if (o is null) Console.WriteLine("it's a const pattern");

            // type pattern
            if (o is Person p) Console.WriteLine($"it's a person {p.FirstName}");
            if (o is Person p2 && p2.FirstName.StartsWith("Jan")) Console.WriteLine($"it's a person starting with Jan {p2.FirstName}");

            // var pattern
            if (o is var x) Console.WriteLine($"it's a var pattern with the type {x?.GetType()?.Name}");
        }

        void SwitchPattern(object o)
        {
            switch (o)
            {
                case null:
                    Console.WriteLine("it's a constant pattern");
                    break;
                case int i:
                    Console.WriteLine("it's an int");
                    break;
                case Person p when p.FirstName.StartsWith("Jan"):
                    Console.WriteLine($"a Jan person {p.FirstName}");
                    break;
                case Person p:
                    Console.WriteLine($"any other person {p.FirstName}");
                    break;
                case var x:
                    Console.WriteLine($"it's a var pattern with the type {x?.GetType().Name} ");
                    break;
                default:
                    break;
            }
        }

        class Person
        {

            public Person(string firstName) :
                this(firstName, string.Empty)
            { }

            public Person(string firstName, string lastName)
            {
                FirstName = firstName;
                LastName = lastName;
            }

            public void Deconstruct(out string firstName, out string lastName)
            {
                firstName = FirstName;
                lastName = LastName;
            }

            public string FirstName { get; set; }
            public string LastName { get; set; }
        }

        #endregion

        #region Binary Literals

        public void BinaryLiterals()
        {
            byte b1 = 0b00001111;
            byte b2 = 0b10101010;
            ushort s1 = 0b1111000011110000;

            Console.WriteLine($"{b1} - {b1:X}");
            Console.WriteLine($"{b2} - {b2:X}");
            Console.WriteLine($"{s1} - {s1:X}");

            byte b3 = 0b0000_1111;

            Console.WriteLine($"{b3} - {b3:X}");
        }

        #endregion

        #region Tuples

        public void Tuples()
        {
            (int x1, string s1) = (3, "one");
            Console.WriteLine($"{x1} {s1}");
        }

        #endregion

        #region Deconstructors

        void Deconstructor()
        {
            (int n, string s) = (42, "magic");

            var p1 = new Person("Tom", "Turbo");
            (string firstName, string lastName) = p1;
        }

        // Extensions - mÙûeme dekonötruovaù aj triedy, ktorÈ nie s˙ "naöe"
        // https://github.com/Burgyn/Sample.DeconstructorsForNonTuple

        #endregion

        #region Expression Bodied Members

        class Person2
        {
            private static ConcurrentDictionary<int, string> names = new ConcurrentDictionary<int, string>();
            private int id = GetId();

            public Person2(string name) => names.TryAdd(id, name); // constructors
            ~Person2() => names.TryRemove(id, out *);              // destructors
            public string Name
            {
                get => names[id];                                 // getters
                set => names[id] = value;                         // setters
            }

            private static int GetId() => 1;
        }

        #endregion

        #region Local Functions

        public void LocalFunctions()
        {
            LocalFunc();

            void LocalFunc()
            {
                Console.WriteLine("Local function called.");
            }
        }

        #endregion

        #region Throw Expressions

        class ThrowExceptions_Old
        {
            private readonly IBookService _booksService;

            public ThrowExceptions_Old(IBookService booksService)
            {
                if (booksService == null)
                {
                    throw new ArgumentNullException(nameof(booksService));
                }

                _booksService = booksService;
            }
        }

        class ThrowExceptions_New
        {
            private readonly IBookService _booksService;

            public ThrowExceptions_New(IBookService booksService)
            {
                _booksService = booksService ?? throw new ArgumentNullException(nameof(booksService));
            }
        }

        public interface IBookService
        { }

        #endregion

        #region Generic Async Return Types

        public async ValueTask<int> Func()
        {
            await Task.Delay(100);
            return 5;
        }

        #endregion
    }
}
