// F# program to compute windchills
// Ishta Bhagat
// U. of Illinois, Chicago
// CS341, Spring 2016
// Homework 4
//
#light

module Functions

let windchill T W = 
  let WC = 35.7+(0.6*T)-(35.7*System.Math.Pow(W, 0.16))+(0.43*T*System.Math.Pow(W, 0.16))
  WC