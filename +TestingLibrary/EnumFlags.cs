using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingLibrary
{
    public static class EnumFlags
    {
        [Flags]
        enum Borders
        {
            None = 0,
            Left = 1,
            Right = 2,
            Bottom = 4,
            Top = 8
        }

        public static void TestFlags()
        {
            var leftAndRight = Borders.Left | Borders.Right;    // Use bitwise OR to combine.
            var topAndBottom = Borders.Top | Borders.Right;
            var allBorders = leftAndRight | topAndBottom;

            Console.WriteLine(allBorders.HasFlag(Borders.Top)   // Use HasFlag to check flag.
                ? "All includes the top."
                : "All does NOT include the top.");

            allBorders ^= Borders.Top;                          // Toggle a flag on/off.
            Console.WriteLine((allBorders & Borders.Top) != 0   // Use bitwise AND to check flag.
                ? "All includes the top."
                : "All does NOT include the top.");
            allBorders ^= Borders.Top;                          // Toggle a flag on/off.
            Console.WriteLine((allBorders & Borders.Top) != 0   // Use bitwise AND to check flag.
                ? "All includes the top."
                : "All does NOT include the top.");
        }
    }
}
