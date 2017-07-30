# Classes and Interfaces

## Classes and Instances

A class describes how a type of component behaves.  An instance is created by calling the `new` operator on the class.
The instance takes up memory, is initialised to the default state using the constructor.  Instances are also called "objects."

It is possible to define fields, properties and methods that are bound to the class and not the instance, using the `static` keyword.
Any static field or property is singular and is stored with the class itself.  A static method has access to the private static
members.

## Methods, Properties and Fields

A C# class can have fields (or member variables), properties and methods (like functions but they affect the class).

| Member Type | Example |
|--------|---------|
| Field | `int fred;` |
| Property | `int TheFred { get; private set; }` |
| Method | `int AddToFred(int val) { fred += val; }` |

Let's give a bit more explanation for each.

### Fields
Fields (or member variables) hold value and make up the state of the class instance.
'State' in this context is like being happy or having so much money - it's the situation.
Fields can be references to other instances (like strings, arrays etc), integers (int, short, long etc), floating point types and  decimal.

### Properties
These are accessor methods that are usually for convenience - usually to answer a question about the state of the instance or to get quick access to something.

#### Implied Backing Field
```cs
public class SimpleProp {
    public string Name { get; private set; }
    public int Age { get; set; }
}
```
Both `Name` and `Age` have an implied field befind them - the actual storage of the state information.

In the example, SimpleProp, the Name reference can be read (and strings are immutable so this is read-only).
The actual field is created by the compiler.  The property actually generated as `getName()` and `setName(string value)` but from C#
they can be called like this:
```cs
class Something {
    private SimpleProp _TheProp;

    public void SimplePropUser() {
        _TheProp = new SimpleProp();
        string name = _TheProp.Name; // <<---- 'calls' on Name property
    }
}
```
The code above actually makes a call on the (hidden method getName) but it looks like a field access.

#### Explicit Backing Field
```cs
public class CheckingProp {
    private int _Count;
    private int _Limit;

    public bool IsOverLimit { get { return _Count > _Limit; } }
}
```

In the class CheckingProp, above, the `IsOverLimit` property can be used to quickly determine if the count
is excessive.  The actual values are explicitly defined above and the property is doing a quick
calculation.

## Access Modifiers - Internal, Public, Private and Protected

C# has different access modifiers that can be applied to methods, properties and fields.

## Contract