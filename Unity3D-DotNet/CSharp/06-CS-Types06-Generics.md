# Types #6 - Generics and Generic Types

## C# Support for Generic Algorithms & Data Structures
Generic algorithms and data structures can be very useful but may not have a natural type.
By natural type, I mean that some concepts need to be expressed in ways that are best suited
by one or two types.  For instance, any algorithms and concepts dealing with text are best
suited for strings as underlying storage; integers and floating point numbers do not help.

An example of a generic data structure is a list.  A list doesn't care about the types
of values it holds, it just knows there is a chain of things that can be presented in order.

An example of a generic algorithm is sort.  As long as the value can be compared for equality and greater-than/less-than
then the values can be sorted.

## C# Generic Collections
As an example of Generic types in action, let's introduce two .NET classes from the generic collections 
namespace - List and Dictionary.

### List
```cs
using System.Collections.Generic;

public class ToDoList {
    private List<string> _ThingsToDo;

    public ToDoList() {
        _ThingsToDo = new List<string>();
    }

    public void AddToDo(string item) {
        _ThingsToDo.Add(item);
    }

    public void CantDoThis() {
        _ThingsToDo.Add( 200 ); // <<--- Error
    }
}
```
Notice that the type `string` is given to the List in 'angled brackets' (really less-than and greater-than)
and that the string type is bound into the List such that trying to add a number to it is
not allowed by the compiler (at compile time).

This means the concept of a 'list' is generic but when it is used and declared with a type, that instance
has a type and that is enforced.

### Dictionary
Dictionary's (in computer science anyway) associate a key with a value.  You could say it gives
the value of the key when you look up the key (that sounds a bit like the book called a dictionary).

In software these are a way to associate one thing with another kind of thing that can be looked
up really efficiently.  The associations are dynamic so they can be added, changed and removed
over time.  Other languages might call this a Hash, a Map or similar names.

```cs
using System.Collections.Generic;

public class Associations {
    private Dictionary<string, int> _HandsToFingers;

    public Associations() {
        _HandsToFingers = new Dictionary<string, int>();
    }

    public void HoldUpFingersInHand(string hand, int numFingers) {
        _HandsToFingers[hand] = numFingers;
    }

    public int HowManyFingersUpFor(string hand) {
        return _HandsToFingers[ hand ];
    }

    public void Setup() {
        HoldUpFingersInHand("Left", 3);
        HoldUpFingersInHand("Right", 5);
    }
}
```

# Defining Your Own Generic Types
This is one of those topics that can have lots of different examples and ideas so I'm
going to show how to define a simple generic type then I'm going to show how to use
constraints to enforce the kind of types that can be used.

## A Custom Generic Type
C# allows you to generalise classes, structures, methods (static and normal) and
delegates.

Here we have an example that allows different types to be stored in a graph node.

```cs

using System;
using System.Collections.Generic;

public class NamedGraphNode<T> {
    private Dictionary<string, NamedGraphNode<T>> _Neighbours;

    public string Name { get; private set; }
    public T Value { get; private set; }

    public NamedGraphNode(string name) {
        Name = name;
        _Neighbours = new Dictionary<string, NamedGraphNode<T>>();
    }

    public NamedGraphNode<T> AddNeighbour(NamedGraphNode<T> other) {
        _Neighbours.Add( other.Name, other);
        other._Neighbours.Add( Name, this);
        return this;
    }

    public IEnumerable<string> Neighbours() {
        return _Neighbours.Keys;
    }

    public bool HasNeighbour(string name) {
        return _Neighbours.ContainsKey(name);
    }

    public bool GetNeighbour(string name, out NamedGraphNode<T> neighbour) {
        if (HasNeighbour(name)) {
            neighbour = _Neighbours[name];
            return true;
        } else {
            neighbour = null;
            return false;
        }
    }
}
```

----
| These Notes         |
|---------------------|
| Warwick Molloy      |
| (c) Copyright 2017  |
