#if INTERACTIVE
#else
module Module5Immutability
#endif


let ImmutabilityDemo() =
    let x = 42
    // x <- 45  ERROR
    let x = 45  // SHADOWING: There's now a "new" x
    x
    printfn "x: %i" x

let ImmutabilityDemo2() =
    let x = 42
    printfn "x: %i" x

    if 1=1 then
        let x = x + 1
        printfn "x: %i" x

    printfn "x: %i" x

let ImmutabilityDemo3() =
    let x = 42
    printfn "x: %i" x

    if 1=1 then
        let x' = x + 1
        printfn "x': %i, x: %i" x' x

    printfn "x: %i" x


let MutabilityDemo() =
    let mutable x = 42
    printfn "x: %i" x
    let x = 45
    printfn "x: %i" x
    x


let RefCellDemo() =
    let x = ref 42
    x := 45     // NOTE the :=
    printfn "x: %i" !x    


let PrintLinesBad() =
    seq {
        let mutable finished = false
        while not finished do
            match System.Console.ReadLine() with
            | null -> finished <- true
            | s -> yield s
    }

let PrintLinesBetter() =
    seq {
        let finished = ref false
        while not !finished do
            match System.Console.ReadLine() with
            | null -> finished := true
            | s -> yield s
    }
    