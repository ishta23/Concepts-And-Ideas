#light

module UnitTests

open NUnit.Framework
open Functions

[<TestFixture>]
type UnitTests() = 
  let L1 = [98; 22; 0; 0; 80; 60; 59; 61; 79; 0]
  let L2 = [0; -1; 59; 12; 01]
  let L3 = [60..100]
  let L4 = [0..100]

  //
  // CountPassing_01:
  //
  [<Test>]
  member this.CountPassing_1_Test_01() = 
    Assert.IsTrue(CountPassing_1 [] = 0)

  [<Test>]
  member this.CountPassing_1_Test_02() = 
    Assert.IsTrue(CountPassing_1 L1 = 5)

  [<Test>]
  member this.CountPassing_1_Test_03() = 
    Assert.IsTrue(CountPassing_1 L2 = 0)

  [<Test>]
  member this.CountPassing_1_Test_04() = 
    Assert.IsTrue(CountPassing_1 L3 = 41)

  [<Test>]
  member this.CountPassing_1_Test_05() = 
    Assert.IsTrue(CountPassing_1 L4 = 41)

  //
  // CountPassing_02:
  //
  [<Test>]
  member this.CountPassing_2_Test_01() = 
    Assert.IsTrue(CountPassing_2 [] = 0)

  [<Test>]
  member this.CountPassing_2_Test_02() = 
    Assert.IsTrue(CountPassing_2 L1 = 5)

  [<Test>]
  member this.CountPassing_2_Test_03() = 
    Assert.IsTrue(CountPassing_2 L2 = 0)

  [<Test>]
  member this.CountPassing_2_Test_04() = 
    Assert.IsTrue(CountPassing_2 L3 = 41)

  [<Test>]
  member this.CountPassing_2_Test_05() = 
    Assert.IsTrue(CountPassing_2 L4 = 41)

  // 
  // contains_1:
  //
  [<Test>]
  member this.contains_1_Test_01() = 
    Assert.IsTrue(contains_1 23 [1;29;16;23;99;11])

  [<Test>]
  member this.contains_1_Test_02() = 
    Assert.IsFalse(contains_1 98 [1;29;16;23;99;11])

  [<Test>]
  member this.contains_1_Test_03() = 
    Assert.IsFalse(contains_1 98 [])

  [<Test>]
  member this.contains_1_Test_04() = 
    Assert.IsTrue(contains_1 "apple" ["orange";"banana";"apple"])

  [<Test>]
  member this.contains_1_Test_05() = 
    Assert.IsFalse(contains_1 "kiwi" ["orange";"banana";"apple"])

  [<Test>]
  member this.contains_1_Test_06() = 
    Assert.IsFalse(contains_1 "kiwi" [])

  // 
  // contains_2:
  //
  [<Test>]
  member this.contains_2_Test_01() = 
    Assert.IsTrue(contains_2 23 [1;29;16;23;99;11])

  [<Test>]
  member this.contains_2_Test_02() = 
    Assert.IsFalse(contains_2 98 [1;29;16;23;99;11])

  [<Test>]
  member this.contains_2_Test_03() = 
    Assert.IsFalse(contains_2 98 [])

  [<Test>]
  member this.contains_2_Test_04() = 
    Assert.IsTrue(contains_2 "apple" ["orange";"banana";"apple"])

  [<Test>]
  member this.contains_2_Test_05() = 
    Assert.IsFalse(contains_2 "kiwi" ["orange";"banana";"apple"])

  [<Test>]
  member this.contains_2_Test_06() = 
    Assert.IsFalse(contains_2 "kiwi" [])

  // 
  // length:
  //
  [<Test>]
  member this.length_Test_01() = 
    Assert.IsTrue(length [] = 0)

  [<Test>]
  member this.length_Test_02() = 
    Assert.IsTrue(length L1 = 10)

  [<Test>]
  member this.length_Test_03() = 
    Assert.IsTrue(length L2 = 5)

  [<Test>]
  member this.length_Test_04() = 
    Assert.IsTrue(length L4 = 101)

  [<Test>]
  member this.length_Test_05() = 
    Assert.IsTrue(length [3.22;2.2;3.10;-2.3;99.5;1.1256] = 6)

  [<Test>]
  member this.length_Test_06() = 
    Assert.IsTrue(length ["apple";"orange";"kiwi";"banana"] = 4)
  
  // 
  // sum:
  //
  [<Test>]
  member this.sum_Test_01() = 
    Assert.IsTrue(sum [] = 0)

  [<Test>]
  member this.sum_Test_02() = 
    Assert.IsTrue(sum L1 = 459)

  [<Test>]
  member this.sum_Test_03() = 
    Assert.IsTrue(sum L2 = 71)

  [<Test>]
  member this.sum_Test_04() = 
    Assert.IsTrue(sum L4 = 5050)

  // 
  // max:
  //
  [<Test>]
  member this.max_Test_01() = 
    Assert.IsTrue(max [123] = 123)

  [<Test>]
  member this.max_Test_02() = 
    Assert.IsTrue(max L1 = 98)

  [<Test>]
  member this.max_Test_03() = 
    Assert.IsTrue(max L2 = 59)

  [<Test>]
  member this.max_Test_04() = 
    Assert.IsTrue(max L3 = 100)

  [<Test>]
  member this.max_Test_05() = 
    Assert.IsTrue(max [-4;-3;-2;-1] = -1)

  [<Test>]
  member this.max_Test_06() = 
    Assert.IsTrue(max [3.22;2.2;3.10;-2.3;99.5;1.1256] = 99.5)

  [<Test>]
  member this.max_Test_07() = 
    Assert.IsTrue(max ["apple";"orange";"kiwi";"banana"] = "orange")
