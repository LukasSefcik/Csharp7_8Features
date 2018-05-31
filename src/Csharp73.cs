using System;

namespace Csharp_8
{
    class Csharp73
    {

        #region Backing Fields Attributes (for auto-implemented properties)

        // Predtým
        [Serializable]
        class FooOld
        {
            [NonSerialized]
            private string MySecret_backingField;

            public string MySecret
            {
                get { return MySecret_backingField; }
                set { MySecret_backingField = value; }
            }
        }

        // Teraz
        [Serializable]
        class FooNew
        {
            [field: NonSerialized]
            public string MySecret { get; set; }
        }

        #endregion

        #region Out Var in initializers

        public class B
        {
            public B(int i, out int j)
            {
                j = i;
            }
        }

        #endregion

        #region Tuple Comparison

        void Compare()
        {
            var x1 = ("a", 1);
            var x2 = ("b", 1);

            bool eq = x1 == x2;
        }

        #endregion

    }
}
