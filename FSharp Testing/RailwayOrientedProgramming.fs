type Result<'TSuccess,'TFailure> = 
    | Success of 'TSuccess
    | Failure of 'TFailure

type Request = {name:string; email:string}

let validateInput input =
   if input.name = "" then Failure "Name must not be blank"
   else if input.email = "" then Failure "Email must not be blank"
   else Success input  // happy path

let bind switchFunction = 
    fun twoTrackInput -> 
        match twoTrackInput with
        | Success s -> switchFunction s
        | Failure f -> Failure f

let bind2 switchFunction twoTrackInput = 
    match twoTrackInput with
    | Success s -> switchFunction s
    | Failure f -> Failure f        

let bind3 switchFunction = 
    function
    | Success s -> switchFunction s
    | Failure f -> Failure f    




let validate1 input =
   if input.name = "" then Failure "Name must not be blank"
   else Success input

let validate2 input =
   if input.name.Length > 50 then Failure "Name must not be longer than 50 chars"
   else Success input

let validate3 input =
   if input.email = "" then Failure "Email must not be blank"
   else Success input    

/// glue the three validation functions together
let combinedValidation = 
    // convert from switch to two-track input
    let validate2WithResultInput = bind validate2
    let validate3WithResultInput = bind validate3
    // connect the two-tracks together
    validate1 >> validate2WithResultInput >> validate3WithResultInput

let combinedValidateInlined =
    validate1 
    >> bind validate2 
    >> bind validate3

let combinedValidationSwitchPiped x = 
    x 
    |> validate1   // normal pipe because validate1 has a one-track input
                   // but validate1 results in a two track output...
    >>= validate2  // ... so use "bind pipe". Again the result is a two track output
    >>= validate3   // ... so use "bind pipe" again. 


// test 1
let input1 = {name=""; email=""}
combinedValidation input1 
|> printfn "Result1=%A"

// ==> Result1=Failure "Name must not be blank"

// test 2
let input2 = {name="Alice"; email=""}
combinedValidation input2
|> printfn "Result2=%A"

// ==> Result2=Failure "Email must not be blank"

// test 3
let input3 = {name="Alice"; email="good"}
combinedValidation input3
|> printfn "Result3=%A"

// ==> Result3=Success {name = "Alice"; email = "good";}


let (>=>) switch1 switch2 x = 
    match switch1 x with
    | Success s -> switch2 s
    | Failure f -> Failure f 


let combinedValidationWithSymbol =
    validate1
    >=> validate2
    >=> validate3

    