module Day9.Problem1

open System

let parseLine (line: string) =
    line.Split(' ')
    |> Seq.map Int32.Parse
    
let parse lines =
    lines
    |> Seq.map parseLine
    
let diffs xs =
    xs
    |> Seq.pairwise
    |> Seq.map (fun (a, b) -> b - a)
    
let generateDiffs xs =
    let allZeroes = xs |> Seq.forall ((=) 0)
    if allZeroes then None
    else Some (xs, diffs xs)
    
let allDiffs xs =
    xs
    |> Seq.unfold generateDiffs
    
let predictNext xs =
    xs
    |> allDiffs
    |> Seq.sumBy Seq.last
    
let solve lines =
    lines
    |> parse
    |> Seq.map predictNext
    |> Seq.sum