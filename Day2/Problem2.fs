module Day2.Problem2

open System.Collections.Generic
open Problem1

let flattenSets (round: Map<string, int> list) =
    round
    |> Seq.map Map.toSeq
    |> Seq.collect id
    
    
let minRequiredForRound (round: Map<string, int> list) =
    round
    |> Seq.map Map.toSeq
    |> Seq.collect id
    |> Seq.groupBy fst
    |> Seq.map (fun (k, v) -> k, (v |> Seq.maxBy snd))
    |> Seq.map (fun (k, v) -> k, snd v)
    |> Map.ofSeq
    
let getPower (set: Map<string, int>) =
    set.Values
    |> Seq.reduce (*)
    
let solve (records: Map<string, int> list seq) =
    records
    |> Seq.map minRequiredForRound
    |> Seq.map getPower
    |> Seq.sum