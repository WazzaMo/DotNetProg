# Types #2 - Value Types
## Overview
Like Scalar Types, Value Types are passed by value when used
in a function call.  But Value Types is the bigger, more general
set... let me explain.

Scalar Types can only represent numbers and Boolean values (true / false)
but what if you wanted to represent complex numbers?

## Structures as Value Types
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

# Standard Structures in .NET
## The Scalar Types have Structure Representation
Each of the scalar types have structures that represent them and provide utility
static methods.  Structures are also Value Types, like the scalars themselves,
so really the C# scalar types and keyword are substituted by the compiler for
their structure counterparts.

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

### Tuples and C# 7
http://our.componentone.com/2017/01/30/tackling-tuples-understanding-the-new-c-7-value-type/

### MSDN Blog - What's New in C# 7
https://blogs.msdn.microsoft.com/dotnet/2016/08/24/whats-new-in-csharp-7-0/

----
| These Notes         |
|---------------------|
| Warwick Molloy      |
| (c) Copyright 2017  |