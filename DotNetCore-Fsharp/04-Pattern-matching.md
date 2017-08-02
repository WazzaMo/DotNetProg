# Pattern Matching

## Patterns and Types
F# has a built-in type called `Option` that represents a maybe value.
This is one of the ways in which F# avoids any kind of NULL value.

```F#
type Option<'Tvalue> =
  | Some of 'Tvalue
  | None
```




# References

### The Option type is very well described in F# For Fun And Profit - see
https://fsharpforfunandprofit.com/posts/the-option-type/

### The concept of *Bind* discussed on F# For Fun and Profit
https://fsharpforfunandprofit.com/posts/computation-expressions-bind/
