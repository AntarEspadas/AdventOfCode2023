module Day8.Problem2

open System.Collections
open System.Collections.Generic
open Microsoft.FSharp.Core

let advance (nodes: Map<string, string * string>) entries c =
    entries
    |> Seq.map (fun x -> Problem1.advance nodes x c )
    
let toTuple (kv: KeyValuePair<'a, 'b>) = kv.Key, kv.Value

let endsWith (c: char) (str: string) = str.EndsWith(c)
    
let getStartingNodes nodes =
    nodes
    |> Seq.map toTuple
    |> Seq.filter (fst >> endsWith 'A')
    
// let isEnd nodes =
//     nodes
//     |> Seq.forall (fst >> endsWith 'Z')

let isEnd nodes =
    nodes
    |> Seq.forall (fst >> endsWith 'Z')
    // key1 |> endsWith 'Z' && key2 |> endsWith 'Z'
    
// Impure function, mutates argument
let next (enumerators: 'a IEnumerator list) =
    let hasNext =
                enumerators
                |> Seq.forall (fun x -> x.MoveNext())
    if not hasNext then None
    else
        enumerators
        |> Seq.map (fun x -> x.Current)
        |> Some
    
// Impure function, mutates argument
let generate state =
    state
    |> next
    |> Option.bind (fun x -> Some(x, state))
    
let transpose (xs: 'a IEnumerable seq) =
    xs
    |> Seq.map (fun x -> x.GetEnumerator())
    |> Seq.toList
    |> Seq.unfold generate
    
// TODO: Make work
let solve lines =
    let directions, nodes = Problem1.parse lines
    
    nodes
    |> getStartingNodes
    |> Seq.map (Problem1.walk directions nodes (fun _ -> false))
    |> transpose
    |> Seq.takeWhile (not << isEnd)
    |> Seq.length