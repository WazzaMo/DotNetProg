# Introduction to Classes
This is the first part on classes and then we'll expand on our discussion of classes.
A class is a definition of a complex entity that stores different types of information
on the Heap.  Being on the Heap gives a number of benefits but they come with some penalty - a tradeoff
between performance and utility - and that's why C# gives you the option for Structures 
and Classes.

Class defintions use Access Modifiers such as `public` and `private` (there are more).
We won't discuss them in detail now but will do so in the next section on classes.
For now it is enough to understand that public things can be used by other class methods
and private things cannot.

## Encapsulation
### In a Simple Class
A simple class is declared innocently enough:
```cs
public class HeapDweller {
    private int _MyCounter;

    public HeapDweller() {
        _MyCounter = 0;
    }

    public int GetCount() {
        return _MyCounter;
    }

    public void IncrementCount() {
        _MyCounter ++;
    }
}
```

The above example defines a counter that it keeps to itself, hence `private` but allows
controlled ways for external caller functions to influence what happens to the counter
via the `GetCount()` and `IncrementCount()` methods.  This is called *Encapsulation*.

A key feature of proper Encapsulation is the isolation or guarding of the internal variable
state by only allowing controlled access to the class, and its state, via public methods.

### A Point of Difference with Functional Programming
Encapsulation is the thing you *don't do* with Functional Programming where primarily pure functions
are used.

Encapsulation is one of the key concepts of Object-Oriented Programming which is why it is such
a point of differentiation with Functional Programming.

## Inheritance
### Building on HeapDweller
Let's say that apart from providing the simple counter functionality, you want
the ability to store and update a text message for the user but count the number
times this is done in the same general count, the you can make a specialised version
of HeapDweller using *Inheritance*.

```cs
public class MessageHeapDweller : HeapDweller {
    private string _Message;

    public MessageHeapDweller() : base() {
        _Message = "";
    }

    public void SetMessage(string updatedMessage) {
        _Message = updatedMessage;
        IncrementCount();
    }

    public string GetMessage() {
        return _Message;
    }
}
```

By the `: HeapDweller` part at the top of the class declaration for `MessageHeapDweller`,
it is telling the C# compiler that this class will be inheriting features from the
`HeapDweller` class and will therefore expose all the same public methods found in
`HeapDweller`.


# References
### Microsoft page describing Object-Oriented Programming and detailed C# class features
https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/object-oriented-programming

----
| These Notes         |
|---------------------|
| Warwick Molloy      |
| (c) Copyright 2017  |