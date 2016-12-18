// F# functions
// Ishta Bhagat 
// U. of Illinois, Chicago
// CS341, Spring 2016
// Homework 5
#light

module Functions

//
// fix:
//

let rec _fix LB UB L L2 = 
  if L = [] then
    List.rev(L2)
  else
    let L3 = 
      if L.Head < LB then
        LB ::L2
      else if L.Head > UB then 
        UB::L2
      else
        L.Head::L2
    _fix LB UB L.Tail L3

let fix LB UB L=
  _fix LB UB L []

// 
// fix2:
//
let rec _fix2 LB UB LL L2=
  if LL=[] then 
    List.rev L2
  else
      let temp =  fix LB UB LL.Head
      _fix2 LB UB LL.Tail (temp::L2)


let fix2 LB UB LL = 
   _fix2 LB UB LL []

//
// reduce:
//
let rec _reduce F L total= 
  if L =[] then 
    total
  else
     let temp = F total L.Head 
     _reduce F L.Tail temp

let reduce F L =
  if List.length L = 1 then
     L.Head
  else
     _reduce F L.Tail L.Head

//
// intAverage:
//
let rec _intAverage L total= 
  if L = [] then 
    total
  else
    let total = total + L.Head
    _intAverage L.Tail total

let intAverage L =
  _intAverage L 0 /List.length L


//
// averages:
//
let rec _avg LL res= 
  if  LL=[] then 
    List.rev res
  else
    _avg LL.Tail (intAverage LL.Head :: res)

let avg LL = 
  _avg LL []

let averages SL LL =
  List.zip SL (avg LL)


// 
// histogram:
//
let rec traverse L LB UB total = 
  if L = [] then 
    total
  else if L.Head > (LB-1) && L.Head < (UB+1) then 
    traverse L.Tail LB UB (total + 1)
  else
    traverse L.Tail LB UB total

//to create the new list 
let rec _histogram L result count = 
  if count = 10 then 
    List.rev result
  else if count = 9 then 
    let temp =  traverse L (count *10) (count*10+10) 0
    _histogram L ([temp] @ result) (count+1)
  else 
    let temp =  traverse L (count *10) (count*10+9) 0
    _histogram L ([temp] @ result) (count+1)
//
let histogram L = 
  let count = 0
  _histogram L [] count

  
