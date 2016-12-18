// F# program to compute windchills
// Ishta Bhagat
// U. of Illinois, Chicago
// CS341, Spring 2016
// Homework 4
//
#light

[<EntryPoint>]
let main argv =
    printf "Please enter temperature (degrees F): "
    let input = System.Console.ReadLine()
    let T = System.Convert.ToDouble(input)

    printf "Please enter max wind speed (MPH): "
    let input = System.Console.ReadLine()
    let MaxWS = System.Convert.ToDouble(input)

    let WS = [1.0 .. MaxWS]
    let windchills = List.map (fun W -> Functions.windchill T W) WS
    printf "" 
    printf "Windchills:"
    printfn "%A" windchills
    printfn ""
    printf ""
    0 // return an integer exit code
