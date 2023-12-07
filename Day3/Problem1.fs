module Day3.Problem1

open System
open System.Collections.Generic
open System.Text.RegularExpressions
open Microsoft.FSharp.Core

type PuzzleNumber = {
    value: int
    first: int
    last: int
    row: int
}

let getAdjacentIndices number =
    let left = number.first - 1
    let right = number.last + 1
    let top =
        seq { left..right }
        |> Seq.map (fun x -> x, number.row + 1)
    let bottom =
        seq { left..right }
        |> Seq.map (fun x -> x, number.row - 1)
    Seq.concat [top; bottom; [left, number.row; right, number.row]]
    
let tryGetChar (cells: string array) (x, y) =
    try Some (cells[y][x])
    with | _ -> None
    
let getAdjacentChars cells number =
    getAdjacentIndices number
    |> Seq.choose (tryGetChar cells)

let isDigit c =
    '0' <= c && c <= '9'
    
let isDot c =
    c = '.'
    
let isSymbol c = not (isDot c || isDigit c)


let hasAdjacentSymbol cells number =
    getAdjacentChars cells number
    |> Seq.filter isSymbol
    |> (not << Seq.isEmpty)
    
let toGrid (rows: string array) =
    rows
    |> Array.map (fun x -> x.ToCharArray())
    
type State =
    | Skipping
    | Reading


let getPuzzleNumber row (m: Match) =
    let value = Int32.Parse m.Value
    {
        value = value
        first = m.Index
        last = m.Index + m.Length - 1
        row = row
    }
    
let re = Regex "\\d+"
let getNumbers row (str: string) =
    re.Matches str
    |> Seq.map (getPuzzleNumber row)
    
let getAllNumbers (lines: string array) =
    lines
    |> Seq.mapi getNumbers
    |> Seq.toList
    
let solve (lines: string array) =
    lines
    |> getAllNumbers
    |> Seq.concat
    |> Seq.map (fun x -> x.value, hasAdjacentSymbol lines x)
    |> Seq.choose (fun (x, y) -> if y then Some(x) else None)
    |> Seq.sum