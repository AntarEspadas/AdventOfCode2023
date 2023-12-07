
open Day3.Problem2

open System.IO

let lines = File.ReadAllLines "/home/antar/repos/AdventOfCode2023/Day3/Input.txt"

// let lines = [|
//     "467..114.."
//     "...*......"
//     ".35..633."
//     ".....#..."
//     "17*......"
//     "....+.58."
//     ".592....."
//     ".....755."
//     "..$.*...."
//     "664.598.."
// |]

lines
|> solve
|> (fun x -> printfn $"%A{x}")