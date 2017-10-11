#if INTERACTIVE
#else
module Module6OO
#endif

type Person(firstname : string, lastname : string) =
    member this.Firstname = firstname
    member this.Lastname = lastname
    member __.Other = "abc" // Example of double underline, is same as "this"

let p1 = Person("Kevin", "Finck")
let p2 = Person("Some", "OtherDude")
let p3 = Person(firstname="Mary", lastname="Smith")
//p3.Firstname <- "AnotherName"     *** Immutable properties


type MutablePerson(firstname : string, lastname : string) =
    let mutable _firstname = firstname

    member this.Firstname
        with get() = _firstname
        and set value = _firstname <- value

    member val Lastname = lastname with get, set    // Short-hand version.

let p4 = MutablePerson("John", "Smith")
p4.Firstname <- "Josy"

open System
type SafePerson(firstname : string, lastname : string) =
    let validateString str = 
        if String.IsNullOrWhiteSpace str then
            raise (ArgumentException())

    do  // Defines the constructor "begin"           
        validateString firstname
        validateString lastname

    member val Firstname = firstname with get, set
    member val Lastname = lastname with get, set
let p5 = SafePerson("You", null)    // Now throws an error.



type IPerson =
    abstract member Firstname : string
    abstract member Lastname: string
    abstract member Fullname: string

type PersonFromInterface(firstname: string, lastname: string) =
    let validateString str = 
        if String.IsNullOrWhiteSpace str then
            raise (ArgumentException())

    // Constructor
    do  // Defines the constructor "begin"           
        validateString firstname
        validateString lastname

    // Interface
    interface IPerson with
        member this.Firstname = firstname
        member this.Lastname = lastname
        member this.Fullname = sprintf "%s %s" firstname lastname
let pi = PersonFromInterface("Yet", "Another")        
printf "\n%s\n" (pi :> IPerson).Fullname;;
