module Slot.Games.Tests.QueenBee.LinesTests

open NUnit.Framework
open Slot.Games.QueenBee

let ss = [|[|2;4;7|];[|3;5;2|];[|9;4;0|];[|4;9;2|];[|3;4;1|]|]
let pl1 = [|4;5;4;9;4|]
let pl2 = [|2;3;9;4;3|]
let pl3 = [|7;2;0;2;1|]
let pl4 = [|2;5;0;9;3|]
let pl5 = [|7;5;9;9;1|]
let pl6 = [|2;3;4;4;3|]
let pl7 = [|7;2;4;2;1|]
let pl8 = [|4;2;0;2;4|]
let pl9 = [|4;3;9;4;4|]
[<Test>]
let TestOnePayLine () =
    let pl = Lines.onePayLine ss
    Assert.AreEqual(pl1, pl Lines.l1)
    Assert.AreEqual(pl2, pl Lines.l2)
    Assert.AreEqual(pl3, pl Lines.l3)
    Assert.AreEqual(pl4, pl Lines.l4)
    Assert.AreEqual(pl5, pl Lines.l5)
    Assert.AreEqual(pl6, pl Lines.l6)
    Assert.AreEqual(pl7, pl Lines.l7)
    Assert.AreEqual(pl8, pl Lines.l8)
    Assert.AreEqual(pl9, pl Lines.l9)
    
   
[<Test>]
let TestPayLines () =
        let r = Lines.payLines Lines.allLines ss
        let er = [|pl1;pl2;pl3;pl4;pl5;pl6;pl7;pl8;pl9|]
        Assert.AreEqual(er, r)


[<Test>]
let TestConsecutive1 () =
    let cf = Lines.consecutiveCount (fun e -> e =3)
    
    let r1 = cf [|2;3;4|]
    Assert.AreEqual(Some(2,2),r1)
    
    let r2 = cf [||]
    Assert.AreEqual(None,r2)
    
    let r3 = cf [|3;3;3|]
    Assert.AreEqual(None,r3)
    
    let r4 = cf [|4;3;4;5;4|]
    Assert.AreEqual(Some(4,3), r4)
    
    let r4 = cf [|4;3;3;3;4|]
    Assert.AreEqual(Some(4,5), r4)
    
    let r5 = cf [|4;5;3;3;4|]
    Assert.AreEqual(Some(4,1), r5)
    
    
[<Test>]
let TestCountForth2Back1 () =
    let cf = Lines.countForth2Back (fun e -> e =3)
    
    let r1 = cf [|2;3;4|]
    Assert.AreEqual((Some(2,2),Some(4,2)),r1)
    
    let r2 = cf [||]
    Assert.AreEqual((None,None),r2)
    
    let r3 = cf [|3;3;3|]
    Assert.AreEqual((None,None),r3)
    
    let r4 = cf [|4;3;4;5;4|]
    Assert.AreEqual((Some(4,3),Some(4,1)), r4)
    
    let r4 = cf [|4;3;3;3;4|]
    Assert.AreEqual((Some(4,5),Some(4,5)), r4)
    
    let r5 = cf [|4;5;3;3;4|]
    Assert.AreEqual((Some(4,1),Some(4,3)), r5)