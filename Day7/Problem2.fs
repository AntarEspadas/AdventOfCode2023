module Day7.Problem2

let equivalences = Map.ofSeq [
    'J', 1
    'T', 10
    'Q', 12
    'K', 13
    'A', 14
]

let countCards cards =
    let jokers, noJokers =
        cards
        |> Seq.toList
        |> List.partition ((=) 1)
    let counts = Problem1.countCards noJokers
    match counts with
    | head :: tail -> (head + jokers.Length) :: tail
    | [] -> [jokers.Length]