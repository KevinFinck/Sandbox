#if INTERACTIVE
#else
module JumpStart
#endif


//type Class1() = 
//    member this.X = "F#"


let Square x = x * x

let SayNumber number =
    printfn "You have %i" number

let Area (length:float) (height:float) : int =
    int (System.Math.Round(length * height))


let Greeting name = 
    if System.String.IsNullOrWhiteSpace(name) then
        "whoever you are"
    else
        name

let SayHi me =
    printfn "Hey %s" (Greeting me)

let PrintNumbers min max =
    let innerSquare x = 
        x * x
    for x in min..max do
        printfn "%i %i" x (innerSquare x)

let position = 1.2, 3.4
System.Console.WriteLine("{0}", position)

let RandomPosition() =
    let r = System.Random()
    r.NextDouble(), r.NextDouble()

let myTuple = RandomPosition()
let val1, val2 = myTuple  // Decompose tuple into it's two values

open System.IO
let files = Directory.EnumerateFiles(@"c:\windows", "*.exe")
