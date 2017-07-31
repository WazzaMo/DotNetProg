# Types #2 - Value Types
## Overview
Like Scalar Types, Value Types are passed by value when used
in a function call so all Scalars are Value Types but Value Types go beyond Scalars, basic numbers and characters,
by supporting `enum` and `struct` declarations.

Imagine you want to represent a set of values that are named and limited in the number of values.
For instance, compass directions North, East, South and West.  This is where *enum*s (short for enumerations) are useful.

What if you wanted to represent complex numbers - with their real and imaginary component?
This is where structures or *struct*s are useful.

## Structures
In C# you can define a structure, using the `struct` keyword, to store multiple values as a Value Type.
There can be performance benefits in doing this in method calls, especially in
repetitive calls, as this is done very efficiently in the .NET runtime with much
less overheads than allocating class instances on the heap - more on this later.

### An Example Structure
```CS
public struct ComplexNumber {
    public int RealComponent;
    public int ImaginaryComponent;
}
```

NOTE: the members do not need to be public and methods can be defined
and decision to go one way or another tends to be based on a Functional Programming
approach or an Object Oriented Approach.

### Using the Complex Number Structure
Having defined a ComplexNumber Value Type, this can be used in functions
for complex number mathematics and can be passed in as arguments and returned
as a value.

```CS
public static ComplexMath {

    public static ComplexNumber Add(ComplexNumber first, ComplexNumber second)
    {
        return new ComplexNumber() {
            RealComponent = first.RealComponent + second.RealComponent,
            Imaginary = first.ImaginaryComponent + second.ImaginaryComponent
        };
    }
}
```

## The Scalar Types have Structure Representation
Each of the scalar types have structures that represent them and provide utility
static methods.  Structures are also Value Types, like the scalars themselves,
so really the C# scalar types and keyword are substituted by the compiler for
their structure counterparts.

## Enumerations - enums
C# lets you define a value that has named values.  The compass points were
used as an example before and in code that looks like this:
```cs
public enum Compass {
    North,
    East,
    South,
    West
}

```
Then these `Compass` values can be used in code and they are passed by value (are Value Types).
For example:
```cs
public static class Foo {
    public static Compass GetSunsDirectionByTime(DateTime moment) {
        if (moment.Hour > 12) {
            return Compass.West;
        } else {
            return Compass.East;
        }
    }
}
```

Enumerations are stored as numeric values under the covers.  The names are treated like constant references
to a value, so for instance `North` might equal `1`, and this makes it easier for .NET to compare
the values and store them.  You can deliberately associate enumerations with
a number type and declare the numeric values you want associated with each name.  The application
of this means you can then rank the names and treat one as being greater than the other.

It is possible to treat enums as bitwise flags which is useful for dealing with low-level hardware
registers and binary protocols or file formats. 
**See enum reference below for more.**

# Alternate Ways to Pass Value Types to a Function or Method

## Passing Value Types by Reference
C# allows a way to pass these types by reference - it's like taking a
 pointer in C - and this can be useful, especially when a function needs
 to return more than one value (C# 7 has better ways to return multiple values, though - "Multi-value or Tuple Returns").

The different ways to pass by reference are:
| Mechanism | Purpose  |
|-----------|-----------|
|  ref      | Pass value by reference so any changes made in the function's scope is seen by the caller. |
|  out      | Pass a reference to the variable with the expectation that the function set a new value, as an extra output. |

For instance, the standard function `TryParse(..)` uses the *out* mechanism
to return the parsed value.

### Pass by 'ref' Works as Expected
To pass by ref the caller must use the `ref` keyword when giving the value
and the function definition must also use the `ref` keyword to indicate
that it accepts references.

The function 'sees' the original value but is also able to change the value
such that the caller 'sees' the same change.

### C# Enforces 'out' Parameters are Outputs
The following code block fails to compile because `imaginary` might not be
set before the function exits.
```CS
        private static bool GetValues(MatchCollection matches, out int real, out int imaginary)
        {
            GroupCollection groups = matches[0].Groups;
            string realBit = groups["real"].Value;
            string imaginaryBit = groups["image"].Value;

            return Int32.TryParse(realBit, out real)
                    && Int32.TryParse(imaginaryBit, out imaginary); // <-- ERROR
        }
```
This is solved by setting a value to `imaginary` on the line above to ensure
it always has a value.

# References
### See the code Example for ValueTypes.
https://github.com/WazzaMo/DotNetProg/tree/master/DotNetCore/Examples/CSharpConsoleApp/ValueTypes

### Enum Types and Uses
https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/enum

### Enum Type Reference (methods)
https://msdn.microsoft.com/en-us/library/system.enum(v=vs.110).aspx

### Tuples and C# 7
http://our.componentone.com/2017/01/30/tackling-tuples-understanding-the-new-c-7-value-type/

### MSDN Blog - What's New in C# 7
https://blogs.msdn.microsoft.com/dotnet/2016/08/24/whats-new-in-csharp-7-0/

----
| These Notes         |
|---------------------|
| Warwick Molloy      |
| (c) Copyright 2017  |