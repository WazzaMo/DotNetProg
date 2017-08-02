# Overview F#

## FSharp Foundation
The community maintaining the FSharp language is facilitated by the FSharp Foundation website - fsharp.org


## Execution
F# is a Functional First language that runs on the .NET / .NET Core / Mono runtimes.
F# can be executed as a compiled .NET language with an ".fs" file, as a scripting language
with ".fsx" files or interactively with the fsi - F# Interactive.

F# can be executed in a browser, client-side using WebSharper in a way that integrates with
the server-side.  Another F# on browser solution is *Fable* an F# to Javascript transpiler.

F# can also execute on a GPU.  See http://fsharp.org/use/gpu/

Strengths of the F# language are:
- makes writing programs that are based on pure functions, with immutable types
easy and supports asynchronous or concurrent programming
- type inference
- type providers that can stream *data* and *types* from data sources that have a schema - databases, R, Matlab. 
- pattern matching
- Options
- eliminate null checking
- piping |>
- tuple destructuring
- record types (different from classes)

Like Python, F# uses whitespace indenting to denote a block and like Python, the language
is expressive in very few lines.

## Core Library
The F# core library provides F# specific classes that are above, and beyond the normal
.NET library.

### F# Collections
Namespace: Microsoft.FSharp.Collections
- Array (2D, 3D, 4D)
- ComparisonIdentity
- HashIdentity
- List
- Map
- Seq
- Set

### F# Execution Control and Messages
Namespace: Microsoft.FSharp.Control

- Async
- Event
- Handler
- IDelegateEvent
- IEvent
- MailboxProcessor

### F# LINQ
Microsoft.FSharp.Linq


# References

### Tour of F#
https://docs.microsoft.com/en-au/dotnet/fsharp/tour

### Azure Notebooks - F#
https://notebooks.azure.com/Microsoft/libraries/fsharp/html/FSharp%20for%20Azure%20Notebooks.ipynb

### GitHub - The F# Language, Library Repository
https://github.com/Microsoft/visualfsharp

### Getting Started
https://docs.microsoft.com/en-us/dotnet/fsharp/get-started/

### Starting with NetCore
https://docs.microsoft.com/en-us/dotnet/fsharp/get-started/get-started-command-line

### F# for Fun and Profit - F# for C# Programmers
https://fsharpforfunandprofit.com/csharp/
