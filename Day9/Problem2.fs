module Day9.Problem2

open Problem1

let predictPrevious xs =
    xs
    |> allDiffs
    |> Seq.map Seq.head
    |> Seq.reduceBack (-)

let solve lines =
    lines
    |> parse
    |> Seq.map predictPrevious
    |> Seq.sum