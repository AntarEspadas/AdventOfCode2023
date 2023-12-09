module Day6.Problem1

open System
open System.Text.RegularExpressions

type Race = {
    time: int64
    record: int64
}

let getRace (time, record) =
    {
        time = time
        record = record
    }

let re = Regex("\\s+")
let parseLine (line: string) =
    line.Split(':')[1]
    |> (fun x -> x.Trim())
    |> re.Split
    |> Seq.map Int64.Parse
    
let parse (lines: string seq) =
    let times = lines |> Seq.head |> parseLine
    let distances = lines |> Seq.item 1 |> parseLine
    Seq.zip times distances
    |> Seq.map getRace

let getDistance timeAllowed timeHeld =
    let timeMoved = timeAllowed - timeHeld
    timeHeld * timeMoved
    
let getOutcomes race =
    seq { 0L .. race.time }
    |> Seq.map (getDistance race.time)
    
let getWinningOutcomes race =
    race
    |> getOutcomes
    |> Seq.filter ((<) race.record)
    
let solve (lines) =
    lines
    |> parse
    |> Seq.map getWinningOutcomes
    |> Seq.map Seq.length
    |> Seq.reduce (*)