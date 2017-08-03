# Controlling Program Flow
## Overview
Programs are instructions followed in a linear fashion, top-to-bottom.
However, to handle real life situations, the flow of instructions must
change to deal with changing circumstances and cannot be followed only top-to-bottom.

## Conditional Statements
When instructions are to be followed based on simple rules, or conditions,
then `if` and `else` statements are very useful.  In C#, the condition
must be written in parentheses and the states to follow should be wrapped
in curly brackets `{` and `}` so the start and end of the conditional
instructions are clear.  The `else` statement means 'otherwise' and allows
for instructions when the opposite of the rule is true but an `else` block
is not mandatory.

### Example 'if'
```cs
void DoWhenCountLarge(int count) {
    if ( count > 5 ) {
        // Instructions for a 'large' count
    }
}
```

### Boolean Operators
Obviously it is important that the rules can be expressed in
terms that arrive at a true or false value.
The values and logic of `true` and `false` are called
Boolean Values and Boolean Logic.  There are operators for Boolean
values (you guessed it - Boolean Operators).

| Operator | Meaning |
|----------|---------|
|    >     | Greater-than |
|    <     | Less-than |
|    >=    | Greater-than-or-equal-to |
|    <=    | Less-than-or-equal-to |
|    ==    | Equal-to |
|    !     | Not (reverses the value) |
|    !=    | Not-equal-to |

Further, it is possible to combine expressions of the above operators with
the Logical-and `&&` operator and the Logical-or `||` operators.

### Example 'if' and 'else'
```cs
void WhenInsideOrOutsideRange(int value) {
    if ( value >= 5 && value <= 10 ) { // value must be between 5 and 10
        // Instructions for when value is within range of 5 and 10
    } else {
        // Instructions when outside range
    }
}
```

### Example If, Else-if And Else
Programs work much more reliably when all possible values are handled
by having a rule for every occasion.  That's why if, else-if and else
are useful combinations.
```cs
void DealWithValuesInLowerRangeUpperRangeOrOtherwise(int value) {
    if ( value >= 2 && value <= 8 ) { // value must be between 5 and 10
        // Instructions for the lower range - 2 through 8
    } else if ( value >= 9 && value <= 16 ) {
        // Instructions for the upper range - 9 through 16
    } else {
        // Instructions for any other value
    }
}
```

## For Loops
There are times when you need to process every value in an array,
or perform some calculation on every possible value in a range of
values.

### Looping Through a Range of Values
Let's say you need to do something for every value between 3 and 9.
For this task, you can use a for-loop and the general structure is as follows:
```
    for( SETUP ; CONDITIONAL_EXPRESSION_TRUE_TO_CONTINUE ; UPDATE ) {
        // Instructions to perform on every loop
    }
```
| Part | Meaning | Example |
|------|---------|---------|
| Setup | Can be the declaration and initialisation of a value. | `int count = 5` |
| Continue Condition | Tests to see if the loop should continue | `count < 10` |
| Update | The change to make to the control value so the loop progresses | `count++` |

Now for a loop from 3 to 9, taking the sum of all values:
```cs
    int SumAllValuesBetweenThreeAndNine() {
        int sumTotal = 0;

        for(int count = 3; count <= 9; count++ ) {
            sumTotal = sumTotal + count;    // can be shortened to 'sumTotal += count;'
        }
        return sumTotal;
    }
```

### Looping Through All Values of an Array
There are many types, arrays being one example, that are enumerable - that means
they represent a group of values that can be stepped through.
C# provides a convenient way to process all values of an enumerable type, using the `foreach` statement.

```cs
int AllInTheArray(int[] SomeGivenArray) {
    int total = 0;
    foreach(int value in SomeGivenArray) {
        total += value;
    }
    return total;
}
```

## Switch-Case
A need may arise where there are a number of special values to handle and using a long
list of if-elseif-else clauses can be inconvenient.  This is where switch-case is useful.



----
| These Notes         |
|---------------------|
| Warwick Molloy      |
| (c) Copyright 2017  |
