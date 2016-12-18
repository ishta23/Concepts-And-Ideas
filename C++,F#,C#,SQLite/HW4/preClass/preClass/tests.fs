#light

module UnitTests

open NUnit.Framework
open Functions

[<TestFixture>]
type UnitTests() = 
  let L1 = [11;15;9]
  let L2 = [11;15;9]
  let L3 = [11;15]
  let L4 = [7;11;15;9]

  //
  // identical:
  //
  [<Test>]
  member this.identical_Test_01() = 
    Assert.IsTrue( identical L1 L2 = true )

  [<Test>]
  member this.identical_Test_02() = 
    Assert.IsTrue( identical L1 L3 = false )
  
  [<Test>]
  member this.identical_Test_03() = 
    Assert.IsTrue( identical L1 L4 = false )

  //
  // addEachPair:
  //
  [<Test>]
  member this.addEachPair_Test_01() = 
    let R = addEachPair [1;2;3;4;5;6;7;8]
    let C = [3;7;11;15]
    Assert.IsTrue( identical R C = true )

  [<Test>]
  member this.addEachPair_Test_02() = 
    let R = addEachPair [1;2;3;4;5;6;7;8;9]
    let C = [3;7;11;15;9]
    Assert.IsTrue( identical R C = true )

  [<Test>]
  member this.addEachPair_Test_03() = 
    let R = addEachPair []
    let C = []
    Assert.IsTrue( identical R C = true )

