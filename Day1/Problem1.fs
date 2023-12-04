module Day1.Day1Problem1

let isDigit c = '0' <= c && c <= '9'

let toInt c = int(c - '0')

let firstDigit seq = seq |> Seq.find isDigit

let lastDigit seq = seq |> Seq.rev |> firstDigit

let calibrationCode (line: string) =
    let first = firstDigit line |> toInt
    let last = lastDigit line |> toInt
    first * 10 + last
    
let solve (input: string list) =
    input
        |> Seq.map calibrationCode
        |> Seq.sum