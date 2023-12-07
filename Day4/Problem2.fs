module Day4.Problem2

open System.Collections.Generic
open Problem1

// let getCards (originalCards: Card list) cardNumbers =
//     cardNumbers
//     |> Seq.map (fun i -> originalCards[i - 1])
    
let getWonCardNumbers card =
    let wins = card
                |> getWins
                |> Seq.length
    if wins = 0 then Seq.empty
    else 
        let start = card.number + 1
        seq { start .. start + wins - 1}
                
// let getNextCards (originalCards: Card list) currentCards =
//     currentCards
//     |> Seq.map getWonCardNumbers
//     |> Seq.collect (getCards originalCards)

let parse input =
    input
    |> Seq.mapi parseLine
    |> Seq.toList
    

// let unfold originalCards (cards: Card seq) =
//     if Seq.isEmpty cards then None
//     else Some(cards, getNextCards originalCards cards)

let expandedCardCount (cards: Card list) =
    let cardCounts = List(Seq.replicate cards.Length 1)
    for card in cards do
        for cardNumber in getWonCardNumbers card do
            let currentCardCount = cardCounts[cardNumber - 1]
            let newCardCount = currentCardCount + cardCounts[card.number - 1]
            cardCounts[cardNumber - 1] <- newCardCount
    cardCounts
    |> Seq.sum
    
let solve input =
    input
    |> parse
    |> expandedCardCount