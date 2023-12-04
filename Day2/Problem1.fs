module Day2.Problem1

open System
open System.Collections.Generic

let parseColourCount (str: string) =
    let arr = str.Split ' '
    let num = Int32.Parse arr[0]
    arr[1], num
    
let parseCubeSet (str: string) =
    str.Split ", "
    |> Seq.map parseColourCount
    |> Map.ofSeq
    
let parseRound (str: string) =
    str.Split "; "
    |> Seq.map parseCubeSet
    |> Seq.toList

let parseGame (line: string) =
    (line.Split ": ")[1]
    |> parseRound
    
let parseLines lines =
    lines
    |> Seq.map parseGame
    
let isColourNumberPossible (bag: Map<String, int>) (colour, number) =
    let available = bag[colour]
    available >= number
    
let toTuple (keyValuePair: KeyValuePair<'a, 'b>) =
    keyValuePair.Key, keyValuePair.Value
    
let isSetPossible bag (set: Map<String, int>) =
    set
    |> Seq.map toTuple
    |> Seq.forall (isColourNumberPossible bag)
    
let isRoundPossible bag round =
    round
    |> Seq.forall (isSetPossible bag)