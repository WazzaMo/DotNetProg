# Types #3 - Namespaces, Arrays and Reference Types
## Namespaces
Namespaces allow .NET code to be organised into hierarchical groups that can
each contain classes and structs.  The hierarchy is achieved by using a 
period '.' between namespace names.

The built-in .NET APIs are organised into namespaces, usually starting with
`System` as the base namespace and this has many fundamental classes.  For
text processing in .NET the namespace `System.Text` and `System.Text.RegularExpressions`
have a lot of useful classes.  The `Program.cs` file in the ValueTypes example
using the regular expressions classes to handle parsing text into a complex
number.

### Example Namespace
```cs
namespace Foo {
    public class MicroFoo {
        //... etc
    }
}

namespace Foo.Bar {
    public class MegaFoo {
        // ... etc
    }
}
```

### Using Namespaces And Fully Qualified Names
In the example above, the `Foo` namespace has a class `MicroFoo` and this can be used as a type in another
code block with a fully qualified name as below:
```cs
public static class FooStuff {
    public static void DoStuffWithFoo() {
        Foo.MicroFoo microFoo = new Foo.MicroFoo();
        // ... now use it here...
    }
}
```

Fully qualified names gets very long-winded so is usually avoided with the `using` keyword.
```cs
using Foo;

public static class FooStuff2 {
    public static void AlsoDoesStuffWithFoo() {
        MicroFoo microFoo = new MicroFoo();
        //... etc
    }
}
```

Sometimes class names collide, however, and that's where fully-qualified names come to the rescue.

```cs
namespace KungFoo {
    public class MicroFoo {

    }

    public static class UsesFoos {
        public static void LotsOfFoosToChoose() {
            Foo.MicroFoo otherFoo = new Foo.MicroFoo();
            KungFoo.MicroFoo ourFoo = new KungFoo.MicroFoo();
            //... and so on...
        }
    }
}
```

## Reference Types
### General
Reference types are used where a larger value entity is needed to store
information for the program.  The general assumption is that the
view of this large entity should be sharable by various parts
of the same program and references to this common entity can be
held by different parts of the program.

.NET provides garbage collection that supports cleaning up large
entities in memory that are no longer needed when all the references
to them have been forgotten (basically overwritten).

### String as an Example of a Built-in Reference Type
C# supports a string of Unicode characters as a datatype - C# has a keyword `string` for this type
and also a class `String` in the `System` namespace called, `System.String` in its fully-qualified form.
Unlike scalar types like integers (int), a string can have a much larger memory footprint, depending on text within.
Because they are reference types, they are allocated on the heap (not stack like value types) 
and garbage collected, automatically, when no longer used.

Passing a string value from a caller to a function or method does not copy the string, as this would be
expensive computationally (involving lots of processing) but instead only a reference is passed.

### Arrays of Values as Another Reference Type
Many languages support the idea of arrays - a single entity make up of a repeated block of things.
Arrays in C# can hold a block of scalar types (bool, int, char etc), of value types (struct, enum) or
references (to reference types).  As such, they are large, complex entities that are allocated
on the heap and are reference types.

Arrays are declared using the square brackets `[`and `]` and each item in the block of items
can be accessed with an index.  Examples will help demonstrate:
#### Basic Array of 3 Integers
```cs
int[] MyNumbers = new int[3] { 10, 20, 30 };
//--
int firstItem = MyNumbers[0];  // Array indicies start with 0
int secondItem = MyNumbers[1];
int thirdItem = MyNumbers[2];
int howManyItems = MyNumbers.Length;
```

### For Deeper Contemplation
References are a variable value where the value is the heap address of the big object in the heap memory.
The key insight, here, is that the .NET Runtime (like a lot of other languages) has two different types
of memory - The Stack and The Heap.

Short term values are stored on the Stack - usually variables and function arguments.
Longer term and larger values (class instances - more later...) are on the Heap.

*Example: C# Code*
```cs
public static class FunctionsHere {
    public static void TheOneFunction() {
        string my_text = "Hello there";
        int count = 0;
    }
}
```
*In memory, this is represented in Stack and Heap as:*

```
|---------|                                   |--------
|  Stack  |                                   |  Heap
|---------|                                   |--------
| (vars)  |
| my_text | ................................> [String: "Hello there"]
| count   |
|---------|
```

### Reference Type Exercise
An exercise for the programmer who wants to understand this at a deeper level:
- Take the `FunctionsHere` code (above) and write a new static function in the class
that takes a string argument, let's call that `TheSecondFunction(string textValue)`
- In `TheSecondFunction(..)` use `Console.WriteLine(..)` to print out the original value of
the string argument.
- Add another line to `TheSecondFunction` that sets the string argument `textValue` to another 
string value in this way `textValue = "Great Day!";`
- In the caller, the `TheOneFunction(..)` method and after the call to the `TheSecondFunction`
print out the `my_text` variable using `Console.WriteLine` - was the value changed?

Consider what happens in the called function when it changes the string reference value
in its scope, that is its state of the stack and how this is unrelated to the variables
in the scope, the stack state, when it returns to the caller.


# References
### See the code Example for ValueTypes for the use of regular expressions
https://github.com/WazzaMo/DotNetProg/tree/master/DotNetCore/Examples/CSharpConsoleApp/ValueTypes



----
| These Notes         |
|---------------------|
| Warwick Molloy      |
| (c) Copyright 2017  |