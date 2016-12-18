// F# program to compute windchills
// Ishta Bhagat
// U. of Illinois, Chicago
// CS341, Spring 2016
// Homework 4
//
#light

module Tests

open NUnit.Framework

[<TestFixture>]
type Tests()=
  [<Test>]
  member this.Windchill_Test_01()=
         let R = Functions.windchill 0.0 25.0
         let Correct = -24.05009
         Assert.IsTrue(System.Math.Abs(R-Correct) < 0.0001)
  [<Test>]
   member this.Windchill_Test_02()=
         let R = Functions.windchill 0.0 20.0
         let Correct = -21.95447
         Assert.IsTrue(System.Math.Abs(R-Correct) < 0.0001)
  [<Test>]
   member this.Windchill_Test_03()=
         let R = Functions.windchill 0.0 10.0
         let Correct = -15.90219
         Assert.IsTrue(System.Math.Abs(R-Correct) < 0.0001)