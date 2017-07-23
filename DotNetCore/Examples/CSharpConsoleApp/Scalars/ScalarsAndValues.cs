/*
 * (c) Copyright 2017 Warwick Molloy
 */

namespace Scalars
{
    public static class ScalarsAndValues {

        public static void CastingRequiredBetweenTypes() {
            uint unsignedNum = 64000;

            int signedNum = (int) unsignedNum; // Needs an explicit cast

            System.Console.WriteLine(
                "The signed version = " + signedNum + "\n"
                + "The unsigned version = " + unsignedNum
            );
        }

        public static void IndicatingTypeInNumericLiterals() {
            float a_value = 500f;

            System.Console.WriteLine("The value in 'a_value' was a float literal because of the 'f' suffix!");
            System.Console.WriteLine("In the value {0}f it's the 'f' that makes it a float", a_value);
            System.Console.WriteLine("otherwise, decimal numbers in code are assumed to be double typed values.");
        }

        public static void PassByValueExampleOne() {
            System.Console.WriteLine("Calling FunctionToPassInto(..) with '56'");
            FunctionToPassInto(56);
        }

        public static void SpecifyingNumberOfHeads() {
            System.Console.WriteLine(
                "This calls FunctionToPassInto(..) but does NOT use the "
                +"default value for the number of heads."
            );
            FunctionToPassInto(200, 3);
        }

        private static void FunctionToPassInto(int countOfFreckles, int NumberOfHeads = 1) {
            System.Console.WriteLine(
                "FunctionToPassInto(..) demonstrates that changing the value "
                + "of a Value Type normally does nothing for the caller but "
                + "will be seen inside the local scope of the function."
            );
            System.Console.WriteLine(
                "So 'countOfFreckles' originally has the value: {0}", countOfFreckles
            );

            countOfFreckles = 10000;

            System.Console.WriteLine("My what a large number of freckles: {0}", countOfFreckles);
            System.Console.WriteLine("... and on how many heads? Answer: {0}", NumberOfHeads);
        }

    }
}