#if INTERACTIVE 
#else
module TestLibrary
#endif

type MyClass() =
    member this.X = "F#";
 
let x = 42
let hi = "Hello"

let SayHiTo me =
    printfn "Hi, %s" me
 
let Square x = x * x

SayHiTo "This fellow"
