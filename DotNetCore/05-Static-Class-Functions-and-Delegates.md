# Static Classes, Functions, Lambdas and Delegates

## Functional Programming and Decomposition
There are times when a pure function is all that is needed because they solve
the problem sufficiently well, is simple to test and maintain and requires
less overhead than Object-Oriented programming.

There is a whole class of languages that foster proper Functional Programming (FP) features
and, while C# has gained increasingly more FP features, it is not a strict FP language.
If you're after an FP language F# is better on the DotNetCore runtime.

## Static Classes
C# being an OO language has the class as the basic unit of a program module.
When you want to write simple functions as C#, they need to be placed in a class
to give them a source code module in which to reside.

C# allows the `static` keyword to appear before a class declaration to enforce
that all member variables and methods are static.  Such a class cannot be instantiated
but can only be used as a place to put static variables and methods (AKA functions).

```CS
public static class PureFuncs
{
    private static int Counter = 0;

    public static int Increment(int value)
    {
        return value + 1;
    }

    public int Decrement(int value)  // <--- Error!! Needs 'static' keyword
    {
        return value - 1;
    }

    public static int GetCounter()
    {
        return Counter;
    }

    public static void Count()
    {
        Counter++;
    }
}
```

## Functions
A function (in the mathematical sense) takes one or more values in as the domain
and produces output in a certain range.  A key feature of a pure function is that
they produce a consistent, predictable output for the same input.

Static methods can be pure functions if they do not store any values in static variables.