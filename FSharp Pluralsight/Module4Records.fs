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


