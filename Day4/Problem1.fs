module Day4.Problem1

open System
open System.Text.RegularExpressions

type Card = {
    winningNumbers: Set<int>
    actualNumbers: int seq
    number: int
}

let re = Regex "\s+"
let parseList (setStr: string) =
    setStr.Trim()
    |> re.Split
    |> Seq.map Int32.Parse

let parseLine lineNum (line: string) =
    let parts = line.Split(':')
    let lists = parts[1]
    let listParts = lists.Split('|')
    {
        winningNumbers =  listParts[0] |> parseList |> Set.ofSeq
        actualNumbers = parseList listParts[1]
        number = lineNum + 1
    }
let parse input =
    input
    |> Seq.mapi parseLine
    
let getWins card =
    card.actualNumbers
    |> Seq.filter card.winningNumbers.Contains
    
let getPoints wins =
    if wins = 0 then 0
    else pown 2 (wins - 1)
    
let solve input =
    input
    |> parse
    |> Seq.map getWins
    |> Seq.map Seq.length
    |> Seq.map getPoints
    |> Seq.sum