# Types #1 - Scalar Types
## Overview
In "Making a Project" we created a project called Scalars, now
let's use it to demonstrate scalar types in C#.

Scalar types are basic values that can be used in calculation or logic decisions, like numbers or boolean true and false.  There are signed and 
unsigned versions.

Simple Scalar Types:
- signed integral: sbyte, short, int, long
- unsigned integral: byte, ushort, uint, ulong
- Unicode character: char
- IEEE floating point: float, double
- high precision decimal: decimal
- boolean: bool

Information is lost when passing a value from one of these types to another
 type. For instance, assigning a signed integer to an unsigned integer loses the sign information. Assigning a Unicode character that supports multi-byte
 characters, to a byte works for ASCII (or English) characters but fails
 miserably for most other langugage characters, such as Japanese, Chinese etc
 without proper conversion.

Variables of scalar type are stored on the stack and because their entire value
is small. As a result of being stored on the stack they are
passed by value in a function call. Scalars are a subset of a "Value Types"
that all share this property of being passed by value in function calls.

## Examples
See the /Examples/CSharpConsoleApp/*Scalars* project.
The static class called *ScalarsAndValues* just has regular functions,
because it is static, so it's easier to see what's going on.

## Exercise
Take a look at the C# language reference and become familiar with the operators that can
be performed on numeric scalar functions, such as + - and so on.

# Reference
### See C# Language Reference on GitHub
https://github.com/dotnet/csharplang/blob/master/spec/introduction.md#types-and-variables

### See Scalar Types Example Code
https://github.com/WazzaMo/DotNetProg/tree/master/DotNetCore/Examples/CSharpConsoleApp/Scalars

----
| These Notes         |
|---------------------|
| Warwick Molloy      |
| (c) Copyright 2017  |