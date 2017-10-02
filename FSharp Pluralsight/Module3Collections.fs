#if INTERACTIVE
#else
module Module3Collections
#endif

let arr = [|1; 4; 10|]
let arrOfTuple = [|1, 4, 10|]
let fruits =
    [|
        "Strawberry"
        "Apple"     // Look ma, no commas.
        "Orange"
        "Tomato?"
    |]
let numbersByOne = [|0..100|]
let numbersByFive = [|0..5..100|]
let squares = [|for i in 0..99 do yield i*i|]

let RandomFruits count = 
    let rand = System.Random()
    let fruits = [|"Apple"; "Orange"; "Banana"|]
    [|
        for i in 1..count do
            let index = rand.Next(3)
            yield fruits.[index]
    |]

let RandomFruits2 count = 
    let rand = System.Random()
    let fruits = [|"Apple"; "Orange"; "Banana"|]
    Array.init count (fun _ ->
        let index = rand.Next(3)
        fruits.[index]
    )
    
// let LikeSomeFruit fruits =
//     for fruit in fruits do
//         printfn "I like %s" fruit
let LikeSomeFruit fruits =
    Array.iter(fun fruit -> printfn "I like %s" fruit) fruits
    
let IsEven n =
    n % 2 = 0

let evenSquares = Array.filter(fun x -> IsEven x) squares
let evenSquaresShortcut = Array.filter(IsEven) squares

let sortedFruit = Array.sort fruits

let someWords = [|"these"; "are"; "just"; "sometimes"; "reallyreally"; "long"; "words"; "kindasortaiguess"|]
let PrintLongWords (words: string[]) = 
    let longWords : string [] = Array.filter(fun word -> word.Length > 8) words
    let sortedLongWords = Array.sort longWords
    Array.iter(fun word -> printfn "%s" word) sortedLongWords

// Forward pipe |>
//      Takes output from preceding function
//      Passes it as last arg of next function
let PrintLongWords2 (words:string[]) =
    words
    |> Array.filter(fun word -> word.Length > 8)
    |> Array.sort
    |> Array.iter(fun word -> printfn "%s" word)



let PrintSquares min max =
    let innerSquare x = 
        x * x
    [|min..max|]
    |> Array.map(fun i -> innerSquare i)
    |> Array.iter(fun word -> printfn "%i" word)    // or:   Array.iter(printfn "%i")

let PrintSquares2 min max =
    let innerSquare x = 
        x * x
    [|min..max|]
    |> Array.map(innerSquare)
    
let list =      // Basically an immutable array
    [0..90]     // But leave out the pipes! 
let printList =
    list
    |> List.iter(printfn "%i")

let listEnum = {0..99}  // "Sequence" is an IEnumerable<>

let listNums = 
    seq {
        for i in 0..99 do
            yield i
    }

let bigFiles = 
    System.IO.Directory.EnumerateFiles(@"C:\Windows")
    |> Seq.map(fun name -> System.IO.FileInfo name)
    |> Seq.filter(fun fi -> fi.Length > 100000L)
    |> Seq.map(fun fi -> fi.Name)
