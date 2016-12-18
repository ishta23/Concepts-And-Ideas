#light

module Functions

//###############################################################
//
// Count and return the # of passing scores (>= 60) in L; use a 
// higher-order approach.  See lecture notes from Wed 02-10.
//
let CountPassing_1 L = 
  -1

// Now use a recursive approach; see lecture notes from Wed 02-10.
let rec CountPassing_2 L =
  -1


//###############################################################
//
// contains e L:  does L contain e?  True or false
//
// Write version 1 using a higher order approach.
//
let contains_1 e L = 
  let L2 = List.filter(fun x -> x =e) L
  let count = List.length L2
  count > 0


// Now write a recursive approach; think base case, inductive case.
let rec contains_2 e L = 
  if L = [] then
    false
  else if L.Head = e then
    true
  else 
  contains_2 e L.Tail


//###############################################################
//
// length L:  return the length of list L
//
// Use a recursive approach; think base case, inductive base.
//
let rec length L = 
  if L =[] then 
  0
  else 
  1+ length L.Tail


//###############################################################
//
// sum L:  return the sum of the elements in list L
//
// Use a recursive approach; think base case, inductive case.
//
let rec sum L = 
  if L = [] then
  0 
  else
  L.Head + sum L.Tail
   


//###############################################################
//
// max L:  return the largest element in list L; assume |L|>0.
//
// Use a recursive approach; think base case, inductive case.
// The difference here is that you need to keep track of the max
// element so far as you are recursively processing the list.  
// Since we don't have variables, the solution is to pass along
// an additional parameter that keeps track of the "maxSoFar".
// This additional parameter also requires the definition of a 
// "helper" function, _max.
//
let rec _max maxSoFar (L: 'a list) =
  if L =[] then 
    maxSoFar
    else if L.Head > maxSoFar then 
    _max L.Head L.Tail
    else
    _max maxSoFar L.Tail

let max (L: 'a list) =  // 'a list ==> a list of any type
  _max L.Head L.Tail    // start with first element as max: