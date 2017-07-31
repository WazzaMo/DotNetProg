# Classes and Interfaces

## Classes and Instances

A class describes how a type of component behaves.  An instance is created by calling the `new` operator on the class.
The instance takes up memory, is initialised to the default state using the constructor.  Instances are also called "objects."

It is possible to define fields, properties and methods that are bound to the class and not the instance, using the `static` keyword.
Any static field or property is singular and is stored with the class itself.  A static method has access to the private static
members.

Class definitions can be nested, that is one class can have another class definition inside it.  It's not a commonly used
practice but it can be useful when creating a fluent API where a method will return another instance and calls can be
chained together.  Nesting class definitions allows the outer class to use the inner classes but not allow the callers
to find or use the inner class explicitly.

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
They are used to control what can access the member:

| Modifier | Description |
|----------|-------------|
| public   | The class or member can be accessed by any other class. |
| protected | Only classes that inherit from the class defining the member can access the member. |
| private  | Anything private can only be accessed by the same class it's declared in - not even subclasses can access them |
| internal | Only classes within the same namespace can access that class or member. |


## Interfaces
C# supports defining a contract about what methods and properties will be available on a class.
Interfaces can be used to define a reference type variable but the value must hold an instance of a class that
implements the interface.

An interface definition has an access modifier (`public` and `internal` are all that make any sense),
the `interface` keyword, the interace name then its body with members expected.  Members are listed
without the access modifier and are expected to be public (or the most accessible modifier) by default
and access modifiers are not allowed.

```cs
public interface INTERFACE_NAME {
    // body - examples below
    string SomeProperty { get; }        // get only property
    string OtherProperty { get; set; }  // gettable and settable property
    void Setup();                       // regular method
}
```

A class implementing an interface declares this by following its name with a colon and a list of
classes it extends (inherits from) and then any and all interfaces it implements.  There is no easy,
visual way to tell class names from interfaces names so interface names start with an 'I' by convention.
If the class does not implement every member declared in the interface, the compiler will raise
and error and stop compilation - interfaces are an enforced contract.

```cs
public class CLASS_NAME : EXTEND_CLASS_1, EXTEND_CLASS_2, I_INTERFACE_1, I_INTERFACE_2 {
    // Body of class
}
```

### Example Interface and Implementations

```cs
public interface IPerson {
    int Age { get; }
    string GetName();
}

public class BasicPerson : IPerson {
    private int _Age;
    private string _Name;

    public BasicPerson(string name, int age) {
        _Name = name;
        _Age = age;
    }

    public int Age { get { return _Age; } }
    public string GetName() { return _Name; }
}

// --- probably from another place in the software ---
public class RecordSystem {
    private IPerson _RecordOwner;

    public RecordSystem(string name, int age) {
        _RecordOwner = new BasicPerson(name, age);
    }
}
```

----
| These Notes         |
|---------------------|
| Warwick Molloy      |
| (c) Copyright 2017  |
