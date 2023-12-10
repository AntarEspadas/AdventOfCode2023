
open Day8.Problem2

open System.IO

let lines = File.ReadLines "/home/antar/repos/AdventOfCode2023/Day8/Input.txt"

// let lines = [
//     "LR"
//     ""
//     "11A = (11B, XXX)"
//     "11B = (XXX, 11Z)"
//     "11Z = (11B, XXX)"
//     "22A = (22B, XXX)"
//     "22B = (22C, 22C)"
//     "22C = (22Z, 22Z)"
//     "22Z = (22B, 22B)"
//     "XXX = (XXX, XXX)"
// ]

lines
|> solve
// [
//     ("11Z", 0)
//     ("22Z", 0)
// ]
// |> isEnd
|> (fun x -> printfn $"%A{x}")