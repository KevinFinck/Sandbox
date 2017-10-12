let x = "abc"
let s = ["Hello World!", "abc"]
//let xyz = String.concat " ", strings

//printfn "%s" xyz
//printfn x

let strings = [ "tomatoes"; "bananas"; "apples" ]
let fullString = String.concat ", " strings
printfn "%s" fullString

let firstthing msg = sprintf "first: %s" msg
let more msg = sprintf "%s and much more" msg

let domore = firstthing >> more 
let domore2 = 
    firstthing "xyz"
    |> more
