using System;

using System.Text.RegularExpressions;

namespace ValueTypes
{
    class Program
    {
        const string COMPLEX_STRING = "22, 34i";

        static void Main(string[] args)
        {
            Console.WriteLine("\t~= Value Types =~\n");

            ComplexNumber complex1 = new ComplexNumber(5, 7);
            ComplexNumber complex2 = new ComplexNumber(4, 2);

            System.Console.WriteLine( $"Complex1: {AsString(complex1)}" );
            System.Console.WriteLine( $"Complex2: {AsString(complex2)}" );

            System.Console.WriteLine("\n-- Adding Two Complex Numbers --");
            Print( Add( complex1, complex2) );

            System.Console.WriteLine("\n-- Pass By Value Demo --");
            PassByValueDemo(complex1, complex2);
            System.Console.WriteLine( $"Complex1: {AsString(complex1)}" );
            System.Console.WriteLine( $"Complex2: {AsString(complex2)}" );

            System.Console.WriteLine("\n-- Pass by Reference Demo --");
            PassByRefDemo(ref complex1);
            System.Console.WriteLine(
                $"Value after pass by ref: {AsString(complex1)}"
            );

            System.Console.WriteLine("\n-- Return by 'out' reference");
            if (TryParse(COMPLEX_STRING, out complex1) )
            {
                System.Console.WriteLine(
                    $"Parsed '{COMPLEX_STRING}' as {AsString(complex1)}"
                );
            }
        }

        public static ComplexNumber Add(ComplexNumber first, ComplexNumber second)
        {
            return new ComplexNumber()
            {
                RealComponent = first.RealComponent + second.RealComponent,
                ImaginaryComponent = first.ImaginaryComponent + second.ImaginaryComponent
            };
        }

        public static void Print(ComplexNumber value)
        {
            System.Console.WriteLine( AsString(value) );
        }

        public static string AsString(ComplexNumber value)
        {
            return $"ComplexNumber[{value.RealComponent} + i{value.ImaginaryComponent}]";
        }

        public static void PassByValueDemo(ComplexNumber one, ComplexNumber two)
        {
            System.Console.WriteLine( $"Original First value: {AsString(one)}" );
            System.Console.WriteLine( $"Original Second value: {AsString(two)}" );

            // Local modification - on stack only
            one = Add(one, one);
            two = Add(two, two);

            System.Console.WriteLine( $"First value doubled: {AsString(one)}" );
            System.Console.WriteLine( $"Second value doubled: {AsString(two)}" );
        }

        public static void PassByRefDemo(ref ComplexNumber modifiable)
        {
            System.Console.WriteLine(
                $"Original value given: {AsString(modifiable)} \n"
                +"Changing real part.."
            );
            modifiable.RealComponent = 23;
        }

        const string PATTERN = @"^(?<real>\d+),\s*(?<image>\d+)i$";
        public static bool TryParse(string text, out ComplexNumber number)
        {
            int realPart = 0;
            int imaginaryPart = 0;
            bool result;

            Regex regex = new Regex(PATTERN);
            var matches = regex.Matches(text);
            if (matches.Count > 0)
            {
                result = GetValues(matches, out realPart, out imaginaryPart);
            }
            else
            {
                result = false;
            }

            number = new ComplexNumber(realPart, imaginaryPart);
            return result;
        }

        private static bool GetValues(MatchCollection matches, out int real, out int imaginary)
        {
            GroupCollection groups = matches[0].Groups;
            string realBit = groups["real"].Value;
            string imaginaryBit = groups["image"].Value;

            imaginary = 0;
            return Int32.TryParse(realBit, out real)
                    && Int32.TryParse(imaginaryBit, out imaginary);
        }
    }
}
