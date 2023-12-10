
open Day9.Problem1
open Day9.Problem2

open System.IO

let lines = File.ReadLines "/home/antar/repos/AdventOfCode2023/Day9/Input.txt"

// let lines = [
//     "0 3 6 9 12 15"
//     "1 3 6 10 15 21"
//     "10 13 16 21 30 45"
// ]

lines
|> solve
|> (fun x -> printfn $"%A{x}")