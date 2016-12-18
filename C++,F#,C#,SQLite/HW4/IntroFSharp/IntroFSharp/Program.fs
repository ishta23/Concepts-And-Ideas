#light

open Functions

//
// main() program:  when you run as an .exe
//
[<EntryPoint>]
let main argv =
  let L = [98; 22; 0; 0; 80; 60; 59; 61; 79; 0]
  let R1 = CountPassing_1 L
  let R2 = CountPassing_2 L
  printfn ""
  printfn "%A" L
  printfn ""
  printfn "CountPassing_1: %A" R1
  printfn "CountPassing_2: %A" R2
  printfn ""
  printfn ""
  printfn "** Run unit tests via Test>>Windows>>Test Explorer..."
  printfn ""
  printfn ""
  0 // return success

