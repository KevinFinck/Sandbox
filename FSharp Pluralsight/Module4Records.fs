#if INTERACTIVE
#else
module Module4Records
#endif

type Person =
    {
        FirstName: string
        LastName: string
    }

let dude = { FirstName = "Mr."; LastName = "Dude" }    
printfn "%s %s is the man!" dude.FirstName dude.LastName

let littleDude = { dude with FirstName = "Little" }
printfn "%s %s is the man!" littleDude.FirstName littleDude.LastName

let another = { FirstName = "Mr."; LastName = "Dude" }    
printfn "Do they match? %b" (dude = another)


type Company = 
    {
        Name : string
        SalesTaxNumber : int option
    }

let myCompany = { Name = "My Co"; SalesTaxNumber = None }    
let myOtherCompany = { Name = "My Co 2"; SalesTaxNumber = Some 1234 }    

let PrintCompany (company : Company) =
    let taxNumberString =
        match company.SalesTaxNumber with
        | Some n -> sprintf " [%i] " n
        | None -> ""

    printfn "%s%s" company.Name taxNumberString

let PrintCompanyWithIf (company : Company) =
    let taxNumberString =
        if company.SalesTaxNumber.IsSome then
            sprintf " [%i] " company.SalesTaxNumber.Value   // Considered an anti-pattern. Match is idomatic to F#.
        else
            ""

    printfn "%s%s" company.Name taxNumberString

type Shape =
    | Square of float
    | Rectangle of float * float
    | Circle of float
    | Inc of Company    // Not a good example, just seeing what happens.

let s = Square 3.4
let r = Rectangle(2.2, 1.9)
let c = Circle 1.0
let cc = Inc myCompany

let drawings = [|s; r; c; cc|]

let Area (shape : Shape) =
    match shape with
    | Square x -> x * x
    | Rectangle(h, w) -> h * w
    | Circle r -> System.Math.PI * r * r
    | Inc c -> 1.0

let totalArea = drawings |> Array.sumBy(fun shape -> Area shape)
let totalArea2 = drawings |> Array.sumBy(Area)


let one = [|23|]
let two = [|12; 45|]
let many =[|1..100|]

let Describe arr =
    match arr with
    | [|x|] -> sprintf "One element: %i" x
    | [|x; y|] -> sprintf "Two elements: %i, %i" x y
    | _ -> sprintf "A longer array"
