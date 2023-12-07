module Day3.Problem2

open Day3.Problem1
open Problem1


let allIndicesOf x xs =
    xs
    |> Seq.mapi (fun i x -> i, x)
    |> Seq.filter (snd >> (=) x)
    |> Seq.map fst

let getGears row (str: string) =
    str
    |> allIndicesOf '*'
    |> Seq.map (fun x -> x, row)
    
let getAllGears (lines: string array) =
    lines
    |> Seq.mapi getGears
    |> Seq.concat
    
    
let isAdjacent (gearX, gearY) number =
    let diff = abs (number.row - gearY)
    if diff > 1 then
        false
    else if gearX < (number.first - 1) then
        false
    else not (gearX > (number.last + 1))
    
let tryGet (xs: 'a list) index =
    try Some (xs[index])
    with _ -> None
    
let getAdjacentValues (xs: 'a list) index =
    seq { index - 1 .. index + 1 }
    |> Seq.choose (tryGet xs)
    
let getAdjacentNumbers numbers (gearX, gearY) =
    getAdjacentValues numbers gearY // Adjacent rows
    |> Seq.concat
    |> Seq.filter (isAdjacent (gearX, gearY))
    
let solve (lines: string array) =
    let numbers = getAllNumbers lines
    lines
    |> getAllGears
    |> Seq.map (getAdjacentNumbers numbers) // Get all adjacent numbers for each gear
    |> Seq.filter (Seq.length >> (=) 2) // Filter gears with exactly two adjacent numbers
    |> Seq.map (Seq.map (fun x -> x.value)) // Get the numeric value for each of the two number
    |> Seq.map (Seq.reduce (*)) // Multiply together the two numbers
    |> Seq.sum