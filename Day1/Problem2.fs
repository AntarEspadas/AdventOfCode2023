module Day1.Day1Problem2

open Day1.Day1Problem1

let wordDigits = Map.ofSeq [
    "one", 1
    "two", 2
    "three", 3
    "four", 4
    "five", 5
    "six", 6
    "seven", 7
    "eight", 8
    "nine", 9
]

let tryGetWordDigit (str: string) =
    wordDigits.Keys
    |> Seq.tryFind str.StartsWith
    |> Option.map (fun x -> wordDigits[x])

let tryGetDigit (str: string) =
    let head = str |> Seq.head
    if (head |> isDigit) then
        Some (int(head - '0'))
    else
        tryGetWordDigit str
        
let getDigits (str: string) =
    Seq.replicate str.Length str
    |> Seq.mapi (fun i x -> x.Substring i)
    |> Seq.map tryGetDigit
    |> Seq.choose id
    
let getCalibrationCode str =
    let digits = getDigits str
    let first = digits |> Seq.head
    let last = digits |> Seq.rev |> Seq.head
    first * 10 + last
    
let solve lines =
    lines
    |> Seq.map getCalibrationCode
    |> Seq.sum