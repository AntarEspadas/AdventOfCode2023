module Day7.Problem1

open System

type Hand =
    {
        cards: int list
        kind: int
    }

type Round =
    {
        hand: Hand
        bid: int
    }
    
let equivalences = Map.ofSeq [
    'T', 10
    'J', 11
    'Q', 12
    'K', 13
    'A', 14
]

let getValue (equivalences: Map<char, int>) c =
    if '2' <= c && c <= '9' then
        int (c - '0')
    else equivalences[c]
         
let parseHand equivalences card =
    card
    |> Seq.map (getValue equivalences)
    |> Seq.toList
    
let countCards cards =
    cards
    |> Seq.countBy id
    |> Seq.map snd
    |> Seq.sortDescending
    |> Seq.toList
    
let getKind countCards (cards: int seq) =
    let counts: int list = countCards cards
    match counts.Length with
    | 1 -> 7 // Five of a kind
    | 2 -> if counts.Head = 4 then 6 else 5 // Four of a kind or Full house
    | 3 -> if counts.Head = 3 then 4 else 3 // Three of a kind or Two pair
    | 4 -> 2 // Two pair
    | 5 -> 1 // High card
    | _ -> failwith "Too many cards"
    
let getHand countCards cards =
    {
        cards = cards
        kind = getKind countCards cards
    }

let parseRound countCards equivalences (round: string) =
    let [| hand; bid |] = round.Trim().Split(' ')
    {
        hand = hand |> parseHand equivalences |> getHand countCards
        bid = Int32.Parse bid
    }

let parse countCards equivalences (lines: string seq) =
    lines
    |> Seq.map (parseRound countCards equivalences)

let compareHands handA handB =
    if handA.kind < handB.kind then -1
    else if handA.kind > handB.kind then 1
    else Seq.compareWith (-) handA.cards handB.cards
    
let compareRound roundA roundB = compareHands roundA.hand roundB.hand

let solve countCards equivalences lines =
    lines
    |> parse countCards equivalences
    |> Seq.sortWith compareRound
    |> Seq.mapi (fun i x -> x.bid * (i + 1))
    |> Seq.sum