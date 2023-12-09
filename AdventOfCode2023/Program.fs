
open Day5.Problem1

open System.IO

let input = File.ReadAllText "/home/antar/repos/AdventOfCode2023/Day5/Input.txt"

// let input = """
// seeds: 79 14 55 13
//
// seed-to-soil map:
// 50 98 2
// 52 50 48
//
// soil-to-fertilizer map:
// 0 15 37
// 37 52 2
// 39 0 15
//
// fertilizer-to-water map:
// 49 53 8
// 0 11 42
// 42 0 7
// 57 7 4
//
// water-to-light map:
// 88 18 7
// 18 25 70
//
// light-to-temperature map:
// 45 77 23
// 81 45 19
// 68 64 13
//
// temperature-to-humidity map:
// 0 69 1
// 1 0 69
//
// humidity-to-location map:
// 60 56 37
// 56 93 4
// """

// let almanac = parse input
//
// printfn $"%A{Seq.head almanac.mappings}"
//
// getTarget (79) (almanac.mappings |> Seq.head |> Seq.last)
input
|> parse
|> (fun x -> x.seeds)
|> Seq.pairwise
|> Seq.indexed
|> Seq.filter (fst >> (fun x -> x % 2) >> (=) 0)
|> Seq.map (snd >> snd)
// |> (fun x -> x.see)
|> Seq.iter (fun x -> printfn $"%A{x}")