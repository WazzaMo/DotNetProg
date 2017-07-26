# Quick F# Examples

Some basic grammar - F# uses `let` to declare a function or constant
and `let mutable` for a variable.

```fs
let MyName = "fred"
```

The compiler determines that `MyName` is a string because "fred" is a string.
To explicitly declare type, place it after the identifier, like this:

```fs
let YourName : string = "Peter"
```

To declare a list of numbers, use the list constant operator `[]` and the range operator `..`
```fs
let MelbourneTemperatures = [ 3 .. 16 ] // range of temperatures
let Coldest = [ -1; 0; 2 ]
```

Declare the `isOdd` function and use it to find the odd values:
```fs
let Numbers = [ 2 .. 24 ]
let isOdd n = n % 2 = 1
let OddNumbers = List.filter isOdd Numbers
```

Use pipeline to pass the list of numbers into the filter function and to do the same thing:
```fs
let TheOddNumberss = 
    [ 2 .. 24 ]
    |> List.filter isOdd
```

Pipelining the values in like this is similar to UNIX pipes.  The function taking the pipe input
must have all but one of its arguments satisfied and the piped in argument needs to match the
required time.  In the above example, `List.filter isOdd` combines to become a function that
needs a list of numbers, that returns a filtered list of numbers.  To demonstrate, it could 
done this way.

```fs
let TheOddFilter a_list =
    List.filter isOdd a_list
```

So now I have composed a new function `TheOddFilter` and I can use it directly or via
pipelining.

```fs
let oddsByDirect = TheOddFilter Numbers

let oddsByPipe =
    Numbers
    |> TheOddFilter
```
