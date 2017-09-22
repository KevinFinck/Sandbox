#load "PigLatin.fs"
open FsharpPluralsight

printfn "Hello %s" "World"

/// Square's the given value.
let square x = x*x
let squared = List.map square [1;2;3]

printfn "%A" squared

let msg = PigLatin.toPigLatin "ByeBye"
printfn "%s" msg

printfn "That's all folks!"