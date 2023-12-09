module Day6.Problem2

open System
open Problem1

let parseLine (line: string) =
    line.Replace(" ", "").Split(':')[1] |> Int64.Parse
    
let parse lines =
    {
        time = lines |> Seq.head |> parseLine
        record = lines |> Seq.item 1 |> parseLine
    }
    
let solve lines =
    lines
    |> parse
    |> getWinningOutcomes
    |> Seq.length