# More on Functional Composition

## Currying in F#
Currying is a way of thinking about functional composition.
Pure functions, in the mathematical sense, should take one input
and produce one output.

For instance, a quatdratic formula:
```math
y = f(x)
f(x) = x^2 + 3x + 2
```

Mathematics allows for formulaic composition:
```math
f(x) = x^2 + 3x/2 + 1
g(x) = 2x

g(f(x)) = 2x^ + 3x + 2
```

In the same way, many functional languages model each parameter as a function, applied in turn.
For instance a function adding two numbers can be seen as two functions taking one parameter.

```F#
let add x y = x + y

let add_x x other = x + other
let add_2 = add_x 2             // Leaves one parameter open - thus this is a function
                                // Type: (int -> int)  meaning a function taking and returning int

let sum_2_and_6 = add_2 6
```

Because all functions, even those taking multiple parameters, are considered like
a composition of smaller functions that each take one argument there is a simple
and consistent model of functional composition.  F# is not unique in this and it's
shared with other functional languages.


# References

### Wikibooks on Higher Order Functions
https://en.wikibooks.org/wiki/F_Sharp_Programming/Higher_Order_Functions

