// Learn more about F# at http://fsharp.org
// See the 'F# Tutorial' project for more help.


let a x y z =
  423

let F x y =
  x *y

[<EntryPoint>]
let main argv = 
    let a = F 10
    let L =[]
    let b = List.length L
    printf"%A" a
    0 // return an integer exit code
