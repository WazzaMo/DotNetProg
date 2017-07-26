// Learn more about F# at http://fsharp.org

open System

open System.IO



let getline() = 
    Console.ReadLine()

let add i j =
    i + j

let getNum() =
    let text = Console.ReadLine()
    Int32.Parse text

[<EntryPoint>]
let main argv =
    printfn "Hello World from F#!"
    let myNum = getNum()
    let sum = add 3 myNum
    printfn "3 + %d = %d" myNum sum 
    // let input = Console.ReadLine()
    let stuff = getline()
    Console.Write("Hello {0}", stuff)
    0 // return an integer exit code
