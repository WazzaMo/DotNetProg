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

Use pipeline and lambda to do the same thing:
```fs
let TheOdds = 
    [ 2 .. 24 ]
    |> List.filter (fun n -> n % 2 = 1)
```
