# Quick F# Examples
## Values
Some basic grammar - F# uses `let` to declare a function or constant
and `let mutable` for a variable.

```F#
let MyName = "fred"
```

The compiler determines that `MyName` is a string because "fred" is a string.
To explicitly declare type, place it after the identifier, like this:

```F#
let YourName : string = "Peter"
```

## Units of Measure
F# thinks of types like sets - as in the full domain of what might be expressed
and determines type equality on that basis.

F# supports defining units of measure on numeric and floating point values
```F#
[<Measure>]
type dollars

let my_money = 5<dollars>                               // the type is int<dollars>
let some_change = 0.20<dollars>                         // the type is float<dollars>
let all_money_in_pocket = my_money + some_change        // ERROR - mismatched numeric type

let my_previous_money = 5.0<dollars>
let money_in_pocket = my_previous_money + some_change   // OK 

let picked_up_from_floor = 50
let now_all_money = my_previous_money + picked_up_from_floor    // ERROR !!
```


## Lists
To declare a list of numbers, use the list constant operator `[]` and the range operator `..`
```F#
let MelbourneTemperatures = [ 3 .. 16 ] // range of temperatures
let Coldest = [ -1; 0; 2 ]
```
## Functions
Functions perform work but are also first-class entities and can be returned as a value
or taken as an argument.

Declare the `isOdd` function and use it to find the odd values:
```F#
let Numbers = [ 2 .. 24 ]
let isOdd n = n % 2 = 1
let OddNumbers = List.filter isOdd Numbers
```

Use pipeline to pass the list of numbers into the filter function and to do the same thing:
```F#
let TheOddNumberss = 
    [ 2 .. 24 ]
    |> List.filter isOdd
```

## Lambda Functions
F# supports declaring a function inline without a name using the `fun` keyword.  They are
wrapped in parentheses to denote the block.
Using lambdas can make declarations
more compact.  Using a lambda makes the above example has only one declaration.
```F#
let oddNumbers =
    [ 2 .. 24 ]
    |> List.filter (fun x -> x % 2 = 1)
```

Here the lambda `(fun x -> x % 2 = 1)` takes the place of the `isOdd` function.
Using lambdas makes sense if the function behaviour will be applied once only.
They can also be useful in declarations for defining composition.

## Functional Composition

Pipelining the values in like this is similar to UNIX pipes.  The function taking the pipe input
must have all but one of its arguments satisfied and the piped in argument needs to match the
required time.  In the above example, `List.filter isOdd` combines to become a function that
needs a list of numbers, that returns a filtered list of numbers.  To demonstrate, it could 
done this way.

```F#
let TheOddFilter a_list =
    List.filter isOdd a_list
```

So now I have composed a new function `TheOddFilter` and I can use it directly or via
pipelining.

```F#
let oddsByDirect = TheOddFilter Numbers

let oddsByPipe =
    Numbers
    |> TheOddFilter
```
Functional composition is a way to make bigger, more sophisticated solutions from
smaller, simpler components.  Compare this to object-based composition that
exists in OO Programming with *has-a* relationships.

# Reference for Quick Examples
## From F# for Fun and Profit
https://fsharpforfunandprofit.com/posts/fsharp-in-60-seconds/

## Units of Measure
https://docs.microsoft.com/en-us/dotnet/fsharp/language-reference/units-of-measure
