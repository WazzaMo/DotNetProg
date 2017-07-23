using System;

namespace Scalars
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("  ~= Scalars example program =~");

            System.Console.WriteLine("\n--CastingRequiredBetweenTypes--");
            ScalarsAndValues.CastingRequiredBetweenTypes();

            System.Console.WriteLine("\n--IndicatingTypeInNumericLiterals--");
            ScalarsAndValues.IndicatingTypeInNumericLiterals();

            System.Console.WriteLine("\n--PassByValueExampleOne--");
            ScalarsAndValues.PassByValueExampleOne();

            System.Console.WriteLine("\n--SpecifyingNumberOfHeads--");
            ScalarsAndValues.SpecifyingNumberOfHeads();
        }
    }
}
