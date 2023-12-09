
open Day6.Problem2

open System.IO

let lines = File.ReadLines "/home/antar/repos/AdventOfCode2023/Day6/Input.txt"

// let lines = [
//     "Time:      7  15   30"
//     "Distance:  9  40  200"
// ]

lines
|> solve
|> (fun x -> printfn $"%A{x}")