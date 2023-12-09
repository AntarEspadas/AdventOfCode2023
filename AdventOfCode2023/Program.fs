
open Day7.Problem1
open Day7.Problem2

open System.IO

let lines = File.ReadLines "/home/antar/repos/AdventOfCode2023/Day7/Input.txt"

// let lines = [
//     "32T3K 765"
//     "T55J5 684"
//     "KK677 28"
//     "KTJJT 220"
//     "QQQJA 483"
// ]

lines
|> solve countCards equivalences
|> (fun x -> printfn $"%A{x}")